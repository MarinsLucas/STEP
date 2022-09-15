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
            this.gg = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFile
            // 
            this.OpenFile.Location = new System.Drawing.Point(19, 13);
            this.OpenFile.Name = "OpenFile";
            this.OpenFile.Size = new System.Drawing.Size(94, 31);
            this.OpenFile.TabIndex = 0;
            this.OpenFile.Text = "Open File";
            this.OpenFile.UseVisualStyleBackColor = true;
            this.OpenFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.AddExtension = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(633, 353);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // linearXAxys
            // 
            this.linearXAxys.Location = new System.Drawing.Point(19, 50);
            this.linearXAxys.Name = "linearXAxys";
            this.linearXAxys.Size = new System.Drawing.Size(94, 29);
            this.linearXAxys.TabIndex = 2;
            this.linearXAxys.Text = "linearXAxys";
            this.linearXAxys.UseVisualStyleBackColor = true;
            this.linearXAxys.Click += new System.EventHandler(this.linearXAxys_click);
            // 
            // linearYAxys
            // 
            this.linearYAxys.Location = new System.Drawing.Point(19, 85);
            this.linearYAxys.Name = "linearYAxys";
            this.linearYAxys.Size = new System.Drawing.Size(94, 29);
            this.linearYAxys.TabIndex = 3;
            this.linearYAxys.Text = "linearYAxys";
            this.linearYAxys.UseVisualStyleBackColor = true;
            this.linearYAxys.Click += new System.EventHandler(this.linearYAxys_click);
            // 
            // linearZAxys
            // 
            this.linearZAxys.Location = new System.Drawing.Point(19, 120);
            this.linearZAxys.Name = "linearZAxys";
            this.linearZAxys.Size = new System.Drawing.Size(94, 29);
            this.linearZAxys.TabIndex = 4;
            this.linearZAxys.Text = "linearZAxys";
            this.linearZAxys.UseVisualStyleBackColor = true;
            this.linearZAxys.Click += new System.EventHandler(this.linearZAxys_click);
            // 
            // XYZ
            // 
            this.XYZ.Location = new System.Drawing.Point(19, 155);
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
            // gg
            // 
            this.gg.Location = new System.Drawing.Point(19, 190);
            this.gg.Name = "gg";
            this.gg.Size = new System.Drawing.Size(94, 29);
            this.gg.TabIndex = 7;
            this.gg.Text = "GG";
            this.gg.UseVisualStyleBackColor = true;
            this.gg.Click += new System.EventHandler(this.gg_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 45);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gg);
            this.splitContainer1.Panel2.Controls.Add(this.OpenFile);
            this.splitContainer1.Panel2.Controls.Add(this.XYZ);
            this.splitContainer1.Panel2.Controls.Add(this.linearXAxys);
            this.splitContainer1.Panel2.Controls.Add(this.linearZAxys);
            this.splitContainer1.Panel2.Controls.Add(this.linearYAxys);
            this.splitContainer1.Size = new System.Drawing.Size(776, 353);
            this.splitContainer1.SplitterDistance = 636;
            this.splitContainer1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.ClientSize = new System.Drawing.Size(800, 410);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
        private Button gg;
        private SplitContainer splitContainer1;
    }
}