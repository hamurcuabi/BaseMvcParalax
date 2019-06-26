using System.Drawing;
using System;
using System.Globalization;
using System.IO;

namespace BaseMvcParalax.Helper
{
    public class ImageHelper
    {

        public static void ResizeAndSave(string path,string imageName,int newWidth, int newHeight)
        {
            System.Drawing.Image image = System.Drawing.Image.FromFile(path);
            float aspectRatio = (float)image.Size.Width / (float)image.Size.Height;
            System.Drawing.Bitmap thumbBitmap = new System.Drawing.Bitmap(newWidth, newHeight);
            System.Drawing.Graphics thumbGraph = System.Drawing.Graphics.FromImage(thumbBitmap);
            thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
            thumbGraph.DrawImage(image, imageRectangle);
            thumbBitmap.Save(imageName, System.Drawing.Imaging.ImageFormat.Png);
            thumbGraph.Dispose();
            thumbBitmap.Dispose();
            image.Dispose();
        }
        public static void SaveImage(string path, int width, int height, string prefix)
        {
            Bitmap imgOrj = (System.Drawing.Image.FromFile(path) as Bitmap);
            // orani bulalim once
            decimal division = Convert.ToDecimal(imgOrj.Width) / Convert.ToDecimal(width) > Convert.ToDecimal(imgOrj.Height) / Convert.ToDecimal(height) ? Convert.ToDecimal(imgOrj.Width) / Convert.ToDecimal(width) : Convert.ToDecimal(imgOrj.Height) / Convert.ToDecimal(height);
            // resimi orantili olarak kucultelim
            Size szProccess = new Size(Convert.ToInt32(imgOrj.Width / division), Convert.ToInt32(imgOrj.Height / division));
            Bitmap imgProccessed = new Bitmap(imgOrj, szProccess);
            // arka planini hazirlayalim
            Bitmap imgBackground = new Bitmap(width, height);
            //// arka plani boyuyalim
            string bg = "FFFFFF".Replace("#", string.Empty);
            Color bgColor = Color.FromArgb(255, Int32.Parse(bg.Substring(0, 2), NumberStyles.HexNumber), Int32.Parse(bg.Substring(2, 2), NumberStyles.HexNumber), Int32.Parse(bg.Substring(4, 2), NumberStyles.HexNumber));

            for (int i = 0; i < width; i++)
            {
                for (int y = 0; y < height; y++)
                {
                    imgBackground.SetPixel(i, y, bgColor);
                }
            }

            // arka planin uzerine yeni resimi koyalim
            Graphics bgImage = Graphics.FromImage(imgBackground);
            int positionX = (width - imgProccessed.Width) / 2;
            int positionY = (height - imgProccessed.Height) / 2;
            bgImage.DrawImage(imgProccessed, positionX, positionY);
            imgBackground.Save(path.Substring(0, path.LastIndexOf("\\", StringComparison.Ordinal) + 1) + Path.GetFileNameWithoutExtension(path) + prefix + ".png", System.Drawing.Imaging.ImageFormat.Png);
            imgOrj.Dispose();
        }
    }
}