using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using System.Reflection;

using AutoCAD;
using System.IO;
using System.Runtime.InteropServices;

using System.Xml;
using System.Xml.Serialization;

using LusasM18_0;

namespace ATK_LusasModeller
{
    public partial class Form1 : Form
    {
        //paths
        string tempDLLPath = @"C:\Temp\aCadScript.dll";
        string tempAcadPolys = @"C:\Temp\tempAcadPolys.xml";
        string tempAcadPoints = @"C:\Temp\tempAcadPoints.xml";
        string tempLusasPolys = @"C:\Temp\tempLusasPolys.xml";

        //constants
        List<double> exeptions = new List<double>();
        double tolerance = 0.0;

        //functional objects
        LusasWinAppClass lusas = null;

        //forms variables
        bool invalidCell = false;
        List<object> columnTypes = new List<object> { 1, 0.0, 1 };

        public Form1()
        {
            InitializeComponent();

            //construct exceptions
            exeptions.Add(0);
            exeptions.Add(9.625);
            exeptions.Add(19.225);

            //construct tolarance
            tolerance = 0.05;

            //get lusas
            try
            {
                lusas = new LusasWinAppClass();
            }
            catch(System.Exception ex)
            {
                MessageBox.Show("could not connect to Lusas. Please make sure a lusas model is open before launching this tool", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {

        }


        //BUTTONS
        private void btn_saveCadInpToXml_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<List<double[]>> surfaceCoordinates = getSurfaceCoordinatesFromLusas();
            savetoXML(surfaceCoordinates);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //connect to acad
            AcadDocument doc = connectAcad();

            //netload script
            netloadToAcad(doc);
        }

        private void btn_getLusasPoint_Click(object sender, EventArgs e)
        {
            //group textboxes
            TextBox[] aCadPoint = {tb_newX, tb_newY, tb_newZ};
            TextBox[] lusasPoint = { tb_exX, tb_exY, tb_exZ };
            TextBox[] translationPoint = { tb_translationX, tb_translationY, tb_translationZ };

            //get acad Position
            double[] positionA = { double.Parse(tb_newX.Text), double.Parse(tb_newY.Text), double.Parse(tb_newZ.Text) };

            //get lusas points
            List<double[]> pointsCoordinates = getPointCoordinatesFromLusas();
            double[] positionB = pointsCoordinates[0];

            //calculate translation
            double[] translation = subtractVectors(positionB, positionA);
            roundCoordinates(translation, tolerance, exeptions);

            //check if coordinates vary in the LUSAS selection
            bool[] coordMismatch = new bool[3];
            for (int i = 0; i < pointsCoordinates[0].Length; i++)
            {
                double coordBase = pointsCoordinates[0][i];
                foreach(double[] point in pointsCoordinates)
                {
                    if (point[i] != coordBase)
                    {
                        coordMismatch[i] = true;
                    }
                }
            }

            //display results
            for (int i = 0; i < positionA.Length; i++)
            {
                if (!coordMismatch[i])
                {
                    lusasPoint[i].Text = positionB[i].ToString();
                    translationPoint[i].Text = translation[i].ToString();
                }
                else
                {
                    lusasPoint[i].Text = "VARIES";
                    translationPoint[i].Text = "VARIES";
                }
            }
        }

        private void btn_getACADPoint_Click(object sender, EventArgs e)
        {
            //get lusas point
            double[] positionA = { double.Parse(tb_exX.Text), double.Parse(tb_exY.Text), double.Parse(tb_exZ.Text) };

            //get ACAD point
            AcadDocument doc = connectAcad();
            double[] positionB = getPointCoordinatesFromACAD(doc)[0];
            tb_newX.Text = positionB[0].ToString();
            tb_newY.Text = positionB[1].ToString();
            tb_newZ.Text = positionB[2].ToString();

            //calculate translation
            double[] translation = subtractVectors(positionA, positionB);
            roundCoordinates(translation, tolerance, exeptions);
            tb_translationX.Text = translation[0].ToString();
            tb_translationY.Text = translation[1].ToString();
            tb_translationZ.Text = translation[2].ToString();

        }

        private void btn_movePoint_Click(object sender, EventArgs e)
        {
            IFSelection selection = lusas.getSelection();
            object points = selection.getObjects("points");
            object[] pointsArray = (object[])points;
            for (int i = 0; i < pointsArray.Length; i++)
            {

            }


        }


        //METHODS
        static public AcadDocument connectAcad()
        {
            // get AutoCAD.Application
            AcadApplication acApp = null;
            AcadDocument doc = null;
            const string strProgId = "AutoCAD.Application";
            try
            {
                acApp = (AcadApplication)Marshal.GetActiveObject(strProgId);
            }
            catch
            {
                MessageBox.Show("Cannot detect an instance of AutoCAD. Please make use AutoCAD is open");
                return doc;
            }

            if (acApp != null)
            {
                try
                {
                    // get active drawing
                    try
                    {
                        doc = acApp.ActiveDocument;
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("Error: " + "could not detect an open drawing");
                        return doc;
                    }
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    return doc;
                }
            }
            return doc;
        }

        public void netloadToAcad(AcadDocument doc)
        {
            //save the autocad script .dll for execution
            string fileName = tempDLLPath;
            File.WriteAllBytes(fileName, Properties.Resources.aCadDllTest);

            // netload the autocad script .dll
            fileName = fileName.Replace("\\", "\\\\");
            doc.SendCommand($"(command \"_netload\" \"{fileName}\") ");
        }

        public List<double[]> getPointCoordinatesFromACAD(AcadDocument doc)
        {
            // launch the command defined in .dll passing it the target path
            doc.SendCommand("SavePointCoordinatesToXML " + tempAcadPoints + "\n");

            //check the vertices file was generated properly at @"C:\Temp\tempstorage.xml"
            try
            {
                bool exists = File.Exists(tempAcadPoints);
                List<double[]> acadPoints = new List<double[]>();
                bool loaded = loadCoordinatesFromXML(tempAcadPoints, ref acadPoints);
                return acadPoints;
            }
            catch
            {
                MessageBox.Show("could not find file with Cad Points", "", MessageBoxButtons.OK);
                return null;
            }
        }

        public List<List<double[]>> getPlylineCoordinatesFromACAD(AcadDocument doc)
        {
            // launch the command defined in .dll passing it the target path
            doc.SendCommand("SavePointCoordinatesToXML " + tempAcadPolys + "\n");

            //check the vertices file was generated properly at @"C:\Temp\tempstorage.xml"
            try
            {
                bool exists = File.Exists(tempAcadPolys);
                List<List<double[]>> acadPolys = new List<List<double[]>>();
                bool loaded = loadCoordinatesFromXML(tempAcadPolys, ref acadPolys);
                return acadPolys;
            }
            catch
            {
                MessageBox.Show("could not find file with Cad Points", "", MessageBoxButtons.OK);
                return null;
            }
        }

        private void drawPolylinesFromXML(AcadDocument doc)
        {
            // launch the command defined in .dll passing it the    
            doc.SendCommand("DrawPolylinesFromXml ");
        }

        public static bool loadCoordinatesFromXML(string filepath, ref List<double[]> polylineCoordinates)
        {
            //List<double[]> surfaceCoordinates = new List<double[]>();
            XmlSerializer serializer = new XmlSerializer(polylineCoordinates.GetType());

            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                polylineCoordinates = serializer.Deserialize(fs) as List<double[]>;
            }
            return true;
        }

        public static bool loadCoordinatesFromXML(string filepath, ref List<List<double[]>> surfaceCoordinates)
        {
            //List<List<double[]>> surfaceCoordinates = new List<List<double[]>>();
            XmlSerializer serializer = new XmlSerializer(surfaceCoordinates.GetType());

            using (FileStream fs = new FileStream(filepath, FileMode.Open))
            {
                surfaceCoordinates = serializer.Deserialize(fs) as List<List<double[]>>;
            }
            return true;
        }

        public static void roundCoordinates(List<double[]> polyline, double precision, List<double> exceptions)
        {
            foreach (double[] point in polyline)
            {
                roundCoordinates(point, precision, exceptions);
            }
        }

        public static void roundCoordinates(double[] point, double tolerance, List<double> exceptions)
        {
            for (int i = 0; i < point.Length; i++)
            {
                point[i] = Math.Round(point[i], 3);
                if (!exceptions.Contains(point[i]) || ((point[i] % 9000) - 7500) == 0)
                {
                    point[i] = Math.Round(point[i] / tolerance) * tolerance;
                }
            }
        }

        public static void offsetCoordinates(List<double[]> polyline,double xoffset, double yoffset, ref double zoffset)
        {
            foreach(double[] vertex in polyline)
            {
                for (int i = 0; i < vertex.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            vertex[i] += xoffset;
                            break;
                        case 1:
                            vertex[i] += yoffset;
                            break;
                        case 2:
                            vertex[i] += zoffset;
                            break;
                    }
                }
            }
        }

        public void modelSurfaceInLusas(List<double[]> vertexes)
        {
            IFGeometryData geoData = lusas.geomData();
            geoData.setAllDefaults();
            geoData.setCreateMethod("planar");
            foreach (double[] vertex in vertexes)
            {
                geoData.addCoords(vertex[0], vertex[1], vertex[2]);
            }
            geoData.setLowerOrderGeometryType("coordinates");
            IFDatabase db = lusas.database();
            db.createSurface(geoData);
        }

        public List<List<double[]>> getSurfaceCoordinatesFromLusas()
        {
            IFSelection userInp = lusas.getSelection();

            //check if selection is at least one point
            if (userInp.countSurfaces() < 1)
            {
                MessageBox.Show("please select at least one point", "", MessageBoxButtons.OK);
                return null;
            }

            //create collection to popoulate surfaces
            List<List<double[]>> surfaces = new List<List<double[]>>();

            for (int i = 0; i < userInp.countSurfaces(); i++)
            {
                //gereate array of ids
                List<int> pointIds = new List<int>();

                //generate collection for populating vertices
                List<double[]> vertexes = new List<double[]>();

                IFSurface surface = userInp.getSurface(i);
                object[] lines = surface.getLOFs() as object[];
                for (int l = 0; l < lines.Length; l++)
                {
                    IFLine line = lines[l] as IFLine;
                    object[] points = line.getLOFs() as object[];
                    for (int k = 0; k < points.Length; k++)
                    {
                        IFPoint point = points[k] as IFPoint;
                        int id = point.getID();

                        if (!pointIds.Contains(id))
                        {
                            pointIds.Add(id);
                            double[] position = new double[3];
                            position[0] = point.getX();
                            position[1] = point.getY();
                            position[2] = point.getZ();
                            //point.getXYZ(position[0],position[1],position[2]);
                            vertexes.Add(position);
                        }
                    }
                }
                surfaces.Add(vertexes);
            }
            return surfaces;
        }

        public List<double[]> getPointCoordinatesFromLusas()
        {
            List<double[]> pointsCoordinates = new List<double[]>();
            IFSelection userInp = lusas.getSelection();
            object points = userInp.getObjects("points");
            object[] pointsArray = (object[])points;

            //check if selection is at least one point
            if (pointsArray.Length < 1)
            {
                MessageBox.Show("please select at least one point", "", MessageBoxButtons.OK);
                return null;
            }

            for (int i = 0; i < pointsArray.Length; i++)
            {
                IFPoint point = (IFPoint)pointsArray[i];
                double[] position = new double[3];
                //point.getXYZ(ref position);
                position[0] = point.getX();
                position[1] = point.getY();
                position[2] = point.getZ();
                pointsCoordinates.Add(position);
            }

            return pointsCoordinates;
        }



        public static double[] subtractVectors(double[] positionA, double[] positionB)
        {
            double[] translation = new double[3];
            for (int i = 0; i < positionA.Length; i++)
            {
                translation[i] = positionB[i] - positionA[i];
            }

            return translation;
        }

        public void savetoXML(List<List<double[]>> polylinesCoordinates)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(polylinesCoordinates.GetType());
            using (TextWriter writer = new StreamWriter(tempLusasPolys))
            {
                xmlSerializer.Serialize(writer, polylinesCoordinates);
            }
        }





        /*
        //FORM VALIDATING BOIS
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string headerText = dgv_inpTable.Columns[e.ColumnIndex].HeaderText;
            int validInt;
            double validDouble;
            invalidCell = false;
            bool filledRow = false;


            foreach (DataGridViewCell cell in dgv_inpTable.Rows[e.RowIndex].Cells)
            {
                if (!(string.IsNullOrEmpty(cell.EditedFormattedValue.ToString())))
                {
                    filledRow = true;
                    break;
                }
            }

            //if its not the last row used for adding rows
            if (e.RowIndex != dgv_inpTable.Rows.Count - 1)
            {
                //if the row is empty
                if (!filledRow)
                {
                    BeginInvoke(new MethodInvoker(delegate { dgv_inpTable.Rows.RemoveAt(e.RowIndex); }));
                }
                else
                {
                    switch (columnTypes[e.ColumnIndex])
                    {
                        case int t1:
                            if (!int.TryParse(e.FormattedValue.ToString(), out validInt) && !string.IsNullOrEmpty(e.FormattedValue.ToString()))
                            {
                                dgv_inpTable.Rows[e.RowIndex].ErrorText = $"Value given for {headerText} should be an Integer";
                                invalidCell = true;
                            }
                            break;
                        case double t2:
                            if (!(double.TryParse(e.FormattedValue.ToString(), out validDouble)))
                            {
                                dgv_inpTable.Rows[e.RowIndex].ErrorText = $"Value given for {headerText} should be an Integer or decimal";
                                invalidCell = true;
                            }
                            break;
                    }
                    if (e.FormattedValue == null)
                    {
                        dgv_inpTable.Rows[e.RowIndex].ErrorText = $"You must enter a value in the {headerText} column";
                        invalidCell = true;
                    }
                }
            }
        }

        private void dgv_inpTable_RowValidating(Object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex != dgv_inpTable.Rows.Count - 1)
            {
                foreach (DataGridViewCell cell in dgv_inpTable.Rows[e.RowIndex].Cells)
                {
                    string headerText = dgv_inpTable.Columns[cell.ColumnIndex].HeaderText;

                    if (string.IsNullOrEmpty(cell.FormattedValue.ToString()))
                    {
                        dgv_inpTable.Rows[cell.RowIndex].ErrorText = $"Value for {headerText} is missing";
                    }
                }
            }
        }

        void dgv_inpTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (!invalidCell)
            {
                // Clear the row error in case the user presses ESC.
                dgv_inpTable.Rows[e.RowIndex].ErrorText = String.Empty;
            }


        }
        */
    }
}