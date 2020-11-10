namespace ATK_LusasModeller
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_saveCadInpToXml = new System.Windows.Forms.Button();
            this.lbl_VerticesTrue = new System.Windows.Forms.Label();
            this.lbl_VerticesFalse = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl_modelFalse = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_netLoad = new System.Windows.Forms.Button();
            this.tb_exX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_exY = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_exZ = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_newZ = new System.Windows.Forms.TextBox();
            this.tb_newY = new System.Windows.Forms.TextBox();
            this.tb_newX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_translationZ = new System.Windows.Forms.TextBox();
            this.tb_translationY = new System.Windows.Forms.TextBox();
            this.tb_translationX = new System.Windows.Forms.TextBox();
            this.btn_getLusasPoint = new System.Windows.Forms.Button();
            this.btn_getACADPoint = new System.Windows.Forms.Button();
            this.btn_movePoint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_saveCadInpToXml
            // 
            this.btn_saveCadInpToXml.Location = new System.Drawing.Point(12, 40);
            this.btn_saveCadInpToXml.Name = "btn_saveCadInpToXml";
            this.btn_saveCadInpToXml.Size = new System.Drawing.Size(75, 23);
            this.btn_saveCadInpToXml.TabIndex = 0;
            this.btn_saveCadInpToXml.Text = "save cad";
            this.btn_saveCadInpToXml.UseVisualStyleBackColor = true;
            this.btn_saveCadInpToXml.Click += new System.EventHandler(this.btn_saveCadInpToXml_Click);
            // 
            // lbl_VerticesTrue
            // 
            this.lbl_VerticesTrue.AutoSize = true;
            this.lbl_VerticesTrue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VerticesTrue.ForeColor = System.Drawing.Color.Green;
            this.lbl_VerticesTrue.Location = new System.Drawing.Point(106, 39);
            this.lbl_VerticesTrue.Name = "lbl_VerticesTrue";
            this.lbl_VerticesTrue.Size = new System.Drawing.Size(23, 25);
            this.lbl_VerticesTrue.TabIndex = 1;
            this.lbl_VerticesTrue.Text = "✓";
            this.lbl_VerticesTrue.Visible = false;
            // 
            // lbl_VerticesFalse
            // 
            this.lbl_VerticesFalse.AutoSize = true;
            this.lbl_VerticesFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VerticesFalse.ForeColor = System.Drawing.Color.Red;
            this.lbl_VerticesFalse.Location = new System.Drawing.Point(107, 41);
            this.lbl_VerticesFalse.Name = "lbl_VerticesFalse";
            this.lbl_VerticesFalse.Size = new System.Drawing.Size(22, 22);
            this.lbl_VerticesFalse.TabIndex = 2;
            this.lbl_VerticesFalse.Text = "X";
            this.lbl_VerticesFalse.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 69);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "draw";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl_modelFalse
            // 
            this.lbl_modelFalse.AutoSize = true;
            this.lbl_modelFalse.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modelFalse.ForeColor = System.Drawing.Color.Red;
            this.lbl_modelFalse.Location = new System.Drawing.Point(105, 85);
            this.lbl_modelFalse.Name = "lbl_modelFalse";
            this.lbl_modelFalse.Size = new System.Drawing.Size(22, 22);
            this.lbl_modelFalse.TabIndex = 4;
            this.lbl_modelFalse.Text = "X";
            this.lbl_modelFalse.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(105, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "✓";
            this.label1.Visible = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 98);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 11;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_netLoad
            // 
            this.btn_netLoad.Location = new System.Drawing.Point(12, 12);
            this.btn_netLoad.Name = "btn_netLoad";
            this.btn_netLoad.Size = new System.Drawing.Size(343, 22);
            this.btn_netLoad.TabIndex = 12;
            this.btn_netLoad.Text = "NETLOAD";
            this.btn_netLoad.UseVisualStyleBackColor = true;
            this.btn_netLoad.Click += new System.EventHandler(this.button4_Click);
            // 
            // tb_exX
            // 
            this.tb_exX.Location = new System.Drawing.Point(97, 223);
            this.tb_exX.Name = "tb_exX";
            this.tb_exX.ReadOnly = true;
            this.tb_exX.Size = new System.Drawing.Size(50, 20);
            this.tb_exX.TabIndex = 13;
            this.tb_exX.Text = "0.0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "X";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Y";
            // 
            // tb_exY
            // 
            this.tb_exY.Location = new System.Drawing.Point(153, 223);
            this.tb_exY.Name = "tb_exY";
            this.tb_exY.ReadOnly = true;
            this.tb_exY.Size = new System.Drawing.Size(50, 20);
            this.tb_exY.TabIndex = 15;
            this.tb_exY.Text = "0.0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Z";
            // 
            // tb_exZ
            // 
            this.tb_exZ.Location = new System.Drawing.Point(209, 223);
            this.tb_exZ.Name = "tb_exZ";
            this.tb_exZ.ReadOnly = true;
            this.tb_exZ.Size = new System.Drawing.Size(50, 20);
            this.tb_exZ.TabIndex = 17;
            this.tb_exZ.Text = "0.0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Lusas Point";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(36, 252);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "New point";
            // 
            // tb_newZ
            // 
            this.tb_newZ.Location = new System.Drawing.Point(209, 249);
            this.tb_newZ.Name = "tb_newZ";
            this.tb_newZ.ReadOnly = true;
            this.tb_newZ.Size = new System.Drawing.Size(50, 20);
            this.tb_newZ.TabIndex = 22;
            this.tb_newZ.Text = "0.0";
            // 
            // tb_newY
            // 
            this.tb_newY.Location = new System.Drawing.Point(153, 249);
            this.tb_newY.Name = "tb_newY";
            this.tb_newY.ReadOnly = true;
            this.tb_newY.Size = new System.Drawing.Size(50, 20);
            this.tb_newY.TabIndex = 21;
            this.tb_newY.Text = "0.0";
            // 
            // tb_newX
            // 
            this.tb_newX.Location = new System.Drawing.Point(97, 249);
            this.tb_newX.Name = "tb_newX";
            this.tb_newX.ReadOnly = true;
            this.tb_newX.Size = new System.Drawing.Size(50, 20);
            this.tb_newX.TabIndex = 20;
            this.tb_newX.Text = "0.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(32, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Translation";
            // 
            // tb_translationZ
            // 
            this.tb_translationZ.Location = new System.Drawing.Point(209, 275);
            this.tb_translationZ.Name = "tb_translationZ";
            this.tb_translationZ.ReadOnly = true;
            this.tb_translationZ.Size = new System.Drawing.Size(50, 20);
            this.tb_translationZ.TabIndex = 26;
            this.tb_translationZ.Text = "0.0";
            // 
            // tb_translationY
            // 
            this.tb_translationY.Location = new System.Drawing.Point(153, 275);
            this.tb_translationY.Name = "tb_translationY";
            this.tb_translationY.ReadOnly = true;
            this.tb_translationY.Size = new System.Drawing.Size(50, 20);
            this.tb_translationY.TabIndex = 25;
            this.tb_translationY.Text = "0.0";
            // 
            // tb_translationX
            // 
            this.tb_translationX.Location = new System.Drawing.Point(97, 275);
            this.tb_translationX.Name = "tb_translationX";
            this.tb_translationX.ReadOnly = true;
            this.tb_translationX.Size = new System.Drawing.Size(50, 20);
            this.tb_translationX.TabIndex = 24;
            this.tb_translationX.Text = "0.0";
            // 
            // btn_getLusasPoint
            // 
            this.btn_getLusasPoint.Location = new System.Drawing.Point(265, 221);
            this.btn_getLusasPoint.Name = "btn_getLusasPoint";
            this.btn_getLusasPoint.Size = new System.Drawing.Size(75, 23);
            this.btn_getLusasPoint.TabIndex = 28;
            this.btn_getLusasPoint.Text = "Get Lusas";
            this.btn_getLusasPoint.UseVisualStyleBackColor = true;
            this.btn_getLusasPoint.Click += new System.EventHandler(this.btn_getLusasPoint_Click);
            // 
            // btn_getACADPoint
            // 
            this.btn_getACADPoint.Location = new System.Drawing.Point(265, 247);
            this.btn_getACADPoint.Name = "btn_getACADPoint";
            this.btn_getACADPoint.Size = new System.Drawing.Size(75, 23);
            this.btn_getACADPoint.TabIndex = 29;
            this.btn_getACADPoint.Text = "Get ACAD";
            this.btn_getACADPoint.UseVisualStyleBackColor = true;
            this.btn_getACADPoint.Click += new System.EventHandler(this.btn_getACADPoint_Click);
            // 
            // btn_movePoint
            // 
            this.btn_movePoint.Location = new System.Drawing.Point(265, 273);
            this.btn_movePoint.Name = "btn_movePoint";
            this.btn_movePoint.Size = new System.Drawing.Size(75, 23);
            this.btn_movePoint.TabIndex = 30;
            this.btn_movePoint.Text = "Move";
            this.btn_movePoint.UseVisualStyleBackColor = true;
            this.btn_movePoint.Click += new System.EventHandler(this.btn_movePoint_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 388);
            this.Controls.Add(this.btn_movePoint);
            this.Controls.Add(this.btn_getACADPoint);
            this.Controls.Add(this.btn_getLusasPoint);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tb_translationZ);
            this.Controls.Add(this.tb_translationY);
            this.Controls.Add(this.tb_translationX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_newZ);
            this.Controls.Add(this.tb_newY);
            this.Controls.Add(this.tb_newX);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_exZ);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_exY);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_exX);
            this.Controls.Add(this.btn_netLoad);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_modelFalse);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbl_VerticesFalse);
            this.Controls.Add(this.lbl_VerticesTrue);
            this.Controls.Add(this.btn_saveCadInpToXml);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_saveCadInpToXml;
        private System.Windows.Forms.Label lbl_VerticesTrue;
        private System.Windows.Forms.Label lbl_VerticesFalse;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl_modelFalse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_netLoad;
        private System.Windows.Forms.TextBox tb_exX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_exY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_exZ;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_newZ;
        private System.Windows.Forms.TextBox tb_newY;
        private System.Windows.Forms.TextBox tb_newX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_translationZ;
        private System.Windows.Forms.TextBox tb_translationY;
        private System.Windows.Forms.TextBox tb_translationX;
        private System.Windows.Forms.Button btn_getLusasPoint;
        private System.Windows.Forms.Button btn_getACADPoint;
        private System.Windows.Forms.Button btn_movePoint;
    }
}

