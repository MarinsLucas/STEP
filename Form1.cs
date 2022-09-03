using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;

namespace STEP
{
    public partial class Form1 : Form
    {
        private string? file_name;
        private float[][]? information;
        private short graphic_type = 0;
        private float width_; 
        private float height_;
        public Form1()
        {
            InitializeComponent();
            file_name = null;
        }
        //draw graphics and axys
        #region draw
        //Draws a simple linear graphic representing a single dimension of telemetry data
        private void drawLinearGraphic(float[] information, Pen pen, string name)
        {
            float h = 0, l = 0;
            for (int i = 0; i < information.Length; i++)
            {
                if (information[i] < l)
                {
                    l = information[i];
                }
                if (information[i] > h)
                {
                    h = information[i];
                }
            }

            height_ = ((h - l) / this.ClientSize.Height) * 1.50f;
            width_ = this.ClientSize.Width / (information.Length);

            Bitmap bitmap = drawLinearAxys(new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb));
            Graphics graphics = Graphics.FromImage(bitmap);
            for (int i = 1; i < information.Length; i++)
            {
                graphics.DrawLine(pen, i*width_, bitmap.Height/2 - information[i - 1]/height_, (i+1)*width_, bitmap.Height/2 - information[i]/height_);
            }
            pictureBox1.Image = bitmap;
        }

        //Draw a linear graphic with all three dimensions of data
        private void drawMultipleLinearGraphics(float[][] information)
        {
            float h = 0, l = 0;
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < information.Length; i++)
                {
                    if (information[j][i] < l)
                    {
                        l = information[j][i];
                    }
                    if (information[j][i] > h)
                    {
                        h = information[j][i];
                    }
                }
            }

            height_ = ((h - l) / this.ClientSize.Height) * 1.50f;
            width_ = this.ClientSize.Width / (information[0].Length);
            //width_ = information[0].Length / this.ClientSize.Width;

            Pen pen = new Pen(Color.White, 1);
            Bitmap bitmap = drawLinearAxys(new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb));
            Graphics graphics = Graphics.FromImage(bitmap);
            for (int j = 0; j<3;j++)
            {
                if (j == 0)
                    pen.Color = Color.Green;
                else if (j == 1)
                    pen.Color = Color.Blue;
                else
                    pen.Color = Color.Red;
                
                for (int i = 1; i < information[j].Length; i++)
                {
                    graphics.DrawLine(pen, i * width_, bitmap.Height/2 - information[j][i - 1] / height_, (i + 1) * width_, bitmap.Height/2- information[j][i] / height_);
                }
            }
            pictureBox1.Image = bitmap;

        }

        //draw g-g diagram
        private void drawGGDiagram(float[][] information)
        {
            //calculating the radio of proportion
            float h=0, l = 0;
            float h_l;
            for(int i = 0; i < information[0].Length; i++)
            {
                if (information[0][i]>h)
                {
                    h = information[0][i];
                }
                if(information[0][i]<l)
                {
                    l = information[0][i];
                }
            }
            h_l = h - l;
            h = 0;
            l = 0; 
            for (int i = 0; i < information[1].Length; i++)
            {
                if (information[1][i] > h)
                {
                    h = information[0][i];
                }
                if (information[1][i] < l)
                {
                    l = information[0][i];
                }
            }

            if(h_l < h-l)
            {
                h_l = h - l; 
            }

            height_ = h_l/ this.ClientSize.Height * 1.50f;
            width_ = height_; 
            Pen pen = new Pen(Color.DarkBlue, 2);
            Bitmap bitmap = drawGGAxys(new Bitmap(pictureBox1.Width, pictureBox1.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb));
            Graphics graphics = Graphics.FromImage(bitmap);

            for(int i = 0; i < information[0].Length; i++)
            {
                graphics.DrawEllipse(pen, new Rectangle((int)(bitmap.Width/2 + information[0][i]/width_),(int) (bitmap.Height/2 - information[1][i]/height_), 2, 2));
            }
            pictureBox1.Image = bitmap;
        }

        private Bitmap drawLinearAxys(Bitmap bitmap)
        {
            Pen pen = new Pen(Color.Black, 2);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.DrawLine(pen, 0, bitmap.Height/2, bitmap.Width, bitmap.Height/2);
            graphics.DrawLine(pen, width_, 0, width_, bitmap.Height);

            return bitmap; 
        }

        private Bitmap drawGGAxys(Bitmap bitmap)
        {
            Pen pen = new Pen(Color.Black, 2);
            Graphics graphics = Graphics.FromImage(bitmap);

            graphics.DrawLine(pen, 0, bitmap.Height / 2, bitmap.Width, bitmap.Height / 2);
            graphics.DrawLine(pen, bitmap.Width/2, 0, bitmap.Width/2, bitmap.Height);

            return bitmap;
        }
        #endregion
        //function that read the file
        private void readingFile(String path)
        {
            using (TextReader reader = File.OpenText(path))
            {
                string text = reader.ReadToEnd();
                
                
                string[] line = text.Split('\n');
                information = new float[3][];
                information[0] = new float[line.Length];
                information[1] = new float[line.Length];
                information[2] = new float[line.Length];

                for (int i = 0; i < line.Length; i++)
                {
                    string[] numbers = line[i].Split(';');
                    information[0][i] = float.Parse(numbers[0]);
                    information[1][i] = float.Parse(numbers[1]);
                    information[2][i] = float.Parse(numbers[2]);
                }
            }
            redraw();
        }
            #region buttons
        private void button1_Click(object sender, EventArgs e)
        {
            //Configuration of openFileDialog1
            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            //opening openFileDialog and displaying the message on the screen
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Open the stream and read 
                file_name = openFileDialog1.FileName;
                graphic_type = 3; 
                readingFile(openFileDialog1.FileName);
            }
        }

        private void linearXAxys_click(object sender, EventArgs e)
        {
            if (file_name != null)
            {
                graphic_type = 0; 
                readingFile(file_name);
            }
        }

        private void linearYAxys_click(object sender, EventArgs e)
        {
            if (file_name != null)
            {
                graphic_type = 1; 
                readingFile(file_name);
            }
        }

        private void linearZAxys_click(object sender, EventArgs e)
        {
            if (file_name != null)
            {
                graphic_type = 2; 
                readingFile(file_name);
            }
        }

        private void linearXYZ_click(object sender, EventArgs e)
        {
            if (file_name != null)
            {
                graphic_type = 3; 
                readingFile(file_name);
            }
        }

        private void gg_Click(object sender, EventArgs e)
        {
            if(file_name != null)
            {
                graphic_type = 4;
                readingFile(file_name);
            }
        }

        #endregion
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X;
            if (information != null)
            {
                textBox1.Text = information[0][(int)x / 10 > information[0].Length? information[0].Length - 1 : (int) x/10].ToString(); //FIXME: out of bounds (of course)
            }
            else
                textBox1.Text = "information not informed";  
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Form1_MouseClick(sender, e);
        }

        private void redraw()
        {
            if (information == null) return;            
            switch (graphic_type)
            {
                case 0:
                    drawLinearGraphic(information[0], new Pen(Color.Green, 1), "x");
                    break;
                case 1:
                    drawLinearGraphic(information[1], new Pen(Color.Blue, 1), "y");
                    break;
                case 2:
                    drawLinearGraphic(information[2], new Pen(Color.Red, 1), "z");
                    break;
                case 3:
                    drawMultipleLinearGraphics(information);
                    break;
                case 4:
                    drawGGDiagram(information);
                    break;
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        { 
            this.pictureBox1.Size = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height - (int)(XYZ.Height * 1.5f));
            redraw();
        }
    }
}