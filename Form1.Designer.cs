namespace STEP
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.OpenFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linearXAxys = new System.Windows.Forms.Button();
            this.linearYAxys = new System.Windows.Forms.Button();
            this.linearZAxys = new System.Windows.Forms.Button();
            this.XYZ = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(22, 369);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(100, 30);
            this.OpenFile.TabIndex = 0;
            this.OpenFile.Text = "Open File";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(776, 314);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // linearXAxys
            // 
            this.linearXAxys.Location = new System.Drawing.Point(223, 369);
            this.linearXAxys.Name = "linearXAxys";
            this.linearXAxys.Size = new System.Drawing.Size(94, 29);
            this.linearXAxys.TabIndex = 2;
            this.linearXAxys.Text = "linearXAxys";
            this.linearXAxys.UseVisualStyleBackColor = true;
            this.linearXAxys.Click += new System.EventHandler(this.linearXAxys_click);
            // 
            // linearYAxys
            // 
            this.linearYAxys.Location = new System.Drawing.Point(323, 370);
            this.linearYAxys.Name = "linearYAxys";
            this.linearYAxys.Size = new System.Drawing.Size(94, 29);
            this.linearYAxys.TabIndex = 3;
            this.linearYAxys.Text = "linearYAxys";
            this.linearYAxys.UseVisualStyleBackColor = true;
            this.linearYAxys.Click += new System.EventHandler(this.linearYAxys_click);
            // 
            // linearZAxys
            // 
            this.linearZAxys.Location = new System.Drawing.Point(423, 370);
            this.linearZAxys.Name = "linearZAxys";
            this.linearZAxys.Size = new System.Drawing.Size(94, 29);
            this.linearZAxys.TabIndex = 4;
            this.linearZAxys.Text = "linearZAxys";
            this.linearZAxys.UseVisualStyleBackColor = true;
            this.linearZAxys.Click += new System.EventHandler(this.linearZAxys_click);
            // 
            // XYZ
            // 
            this.XYZ.Location = new System.Drawing.Point(523, 369);
            this.XYZ.Name = "XYZ";
            this.XYZ.Size = new System.Drawing.Size(94, 29);
            this.XYZ.TabIndex = 5;
            this.XYZ.Text = "XYZ";
            this.XYZ.UseVisualStyleBackColor = true;
            this.XYZ.Click += new System.EventHandler(this.linearXYZ_click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(776, 27);
            this.textBox1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 405);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.XYZ);
            this.Controls.Add(this.linearZAxys);
            this.Controls.Add(this.linearYAxys);
            this.Controls.Add(this.linearXAxys);
            this.Controls.Add(this.OpenFile);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button OpenFile;
        private OpenFileDialog openFileDialog1;
        private PictureBox pictureBox1;
        private Button linearXAxys;
        private Button linearYAxys;
        private Button linearZAxys;
        private Button XYZ;
        private TextBox textBox1;
    }
}