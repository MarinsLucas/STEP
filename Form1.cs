using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;

namespace STEP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Draws a simple linear graphic representing a single dimension of telemetry data
        private void drawLinearGraphic(int[] information, Pen pen, string name)
        {
            Bitmap bitmap = new Bitmap(1000, 800, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            for (int i = 1; i < information.Length; i++)
            {
                graphics.DrawLine(pen, i * 10, information[i - 1], (i + 1) * 10, information[i]);
            }

            bitmap.Save(name + ".png");
        }

        private void drawMultipleLinearGraphics(int[][] information)
        {
            Pen pen = new Pen(Color.White, 1);
            Bitmap bitmap = new Bitmap(1000, 800, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
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
                    graphics.DrawLine(pen, i * 10, information[j][i - 1], (i + 1) * 10, information[j][i]);
                }
            }

            bitmap.Save("xyz.png");
        }

        private void readingFile(String path)
        {
            int [][] information;
            using (TextReader reader = File.OpenText(path))
            {
                string text = reader.ReadToEnd();
                
                
                string[] line = text.Split('\n');
                information = new int[3][];
                information[0] = new int[line.Length];
                information[1] = new int[line.Length];
                information[2] = new int[line.Length];

                for (int i = 0; i < line.Length; i++)
                {
                    string[] numbers = line[i].Split(';');
                    information[0][i] = int.Parse(numbers[0]);
                    information[1][i] = int.Parse(numbers[1]);
                    information[2][i] = int.Parse(numbers[2]);
                }
            }


            //Debug with random numbers
            /*
             * for(int i=0;i<150;i++)
            {
                information[i] = new Random().Next(720);
            }
            */
            drawLinearGraphic(information[0], new Pen(Color.Green, 1), "x");
            drawLinearGraphic(information[1], new Pen(Color.Blue, 1), "y");
            drawLinearGraphic(information[2], new Pen(Color.Red, 1), "z");

            drawMultipleLinearGraphics(information);


        }

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
                readingFile(openFileDialog1.FileName);
            }

        }
    }
}