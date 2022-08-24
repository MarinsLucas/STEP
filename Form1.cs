using Microsoft.VisualBasic.ApplicationServices;
using System.Diagnostics;
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
        private void drawLinearGraphic(int[] information, Pen pen)
        {
            Bitmap bitmap = new Bitmap(1000, 800, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            for (int i = 1; i < information.Length; i++)
            {
                graphics.DrawLine(pen, i * 10, information[i - 1], (i + 1) * 10, information[i]);
            }

            bitmap.Save("graphic.png");
        }

        private void readingFile(String path)
        {
            /*
            using (FileStream fs = File.OpenRead(path))
            {
                byte[] b = new byte[1024];
                UTF8Encoding temp = new UTF8Encoding(true);
                String text = null;
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    text += temp.GetString(b) + " ";
                }
                textBox1.Text = text;
            }
            */
            int [] information;
            using (TextReader reader = File.OpenText(path))
            {
                string text = reader.ReadToEnd();
                string[] bits = text.Split(';'); //get all the numbers from file in strings
                information = new int[bits.Length];
                for (int i = 0; i < bits.Length; i++)
                {
                    try
                    {
                        information[i] = int.Parse(bits[i]);
                    }
                    catch (System.FormatException e)
                    {
                        continue;
                    }
                }
            }


            //Debug with random numbers
            /*
             * for(int i=0;i<150;i++)
            {
                information[i] = new Random().Next(720);
            }
            */
            drawLinearGraphic(information, new Pen(Color.White, 1));
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