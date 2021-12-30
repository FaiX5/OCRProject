using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Patagames.Ocr;
using System.Drawing;
using System.Drawing.Imaging;

namespace OCRProject
{
    public partial class Form1 : Form
    {
        public const string loadimg = @"C:\Users\Fahim Rahmathali\source\repos\OCRProject\OCRProject\images\WhatsApp Image 2021-12-30 at 11.21.08 AM.jpeg";
        public Form1()
        {
            InitializeComponent();
            LoadImage();
          TestBigImagePartDrawing();// croping and resolution adjusting
            pictureBox2.ImageLocation = loadimg;
            

            //try // using Utils.Image;

            //var path = $@"path-to-file\file.extension";
            //  var image = System.Drawing.Image.FromFile(path);

            // Resize image 500x500
            //  var resized = image.Resize(new System.Drawing.Size(500, 500));

            // Rotate 90 degrees counter clockwise
            //  var rotated = image.Rotate(-90);
















            //  using (Bitmap bitmap = (Bitmap)Image.FromFile(@""))
            //  {
            //using (Bitmap newBitmap = new Bitmap(bitmap))
            //  {
            //   newBitmap.SetResolution(300, 300);
            //   Bitmap objBitmap = new Bitmap(objImage, new Size(227, 171));

            //  newBitmap.Save(@"C:\Users\Fahim Rahmathali\source\repos\OCRProject\OCRProject\images\file300.jpg", ImageFormat.Jpeg);
            //  }
            //  }




        }
        
        static Bitmap LoadImage()
        {
          
            return (Bitmap)Bitmap.FromFile(loadimg); // here is large image 9222x9222 pixels and 95.96 dpi resolutions
            
        }

        static void TestBigImagePartDrawing()
        {
            using (var absentRectangleImage = LoadImage())
            {
                using (var currentTile = new Bitmap(499,200))
                {
                    currentTile.SetResolution(absentRectangleImage.HorizontalResolution, absentRectangleImage.VerticalResolution);

                    using (var currentTileGraphics = Graphics.FromImage(currentTile))
                    {
                        currentTileGraphics.Clear(Color.Black);
                        var absentRectangleArea = new Rectangle(588, 600, 1050, 797);
                        currentTileGraphics.DrawImage(absentRectangleImage, 0, 0, absentRectangleArea, GraphicsUnit.Pixel);
                    }

                    currentTile.Save(@"C:\Users\Fahim Rahmathali\source\repos\OCRProject\OCRProject\images\file300.jpg");
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = @"C:\Users\Fahim Rahmathali\source\repos\OCRProject\OCRProject\images\file300.jpg";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var objOcr = OcrApi.Create())
            {
                objOcr.Init( Patagames.Ocr.Enums.Languages.English);
                string palinText = objOcr.GetTextFromImage(pictureBox1.ImageLocation);
                textBox1.Text = palinText;
                    }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
