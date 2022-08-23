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

        private void drawGraphic(int[] information)
        {
            Bitmap bitmap = new Bitmap(1000, 800, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics graphics = Graphics.FromImage(bitmap);
            Pen pen = new Pen(Color.Blue, 2);
            for (int i = 0; i < information.Length; i++)
            {
                graphics.DrawLine(pen, i * 10, information[i - 1], (i + 1) * 10, information[i]);
            }

            bitmap.Save("graphic.png");
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
                string path = openFileDialog1.FileName;
                //Open the stream and read it.  
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
            }

        }
    }
}