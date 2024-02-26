using System;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

namespace WpfApp1.RoadElements
{
    class Elements
    {
        public BitmapImage GetBitmapImage(string element, Image name)
        {
            string imagePath = $"C:\\Users\\Родион\\Source\\Repos\\IntelligSyst\\WpfApp1\\img\\{element}.png";
    BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();
            return bitmap;
            //Console.WriteLine(GetColorFromImage(imagePath, x, y));
        }
        private Color GetColorFromImage(BitmapSource source, int x, int y)
        {
            // Ensure location is within the bounds of the image
            if (x > source.PixelWidth - 1 || y > source.PixelHeight - 1)
                return Colors.Transparent;

            // Prepare to read the pixels
            CroppedBitmap croppedBitmap = new CroppedBitmap(source, new Int32Rect(x, y, 1, 1));
            byte[] pixels = new byte[4];
            croppedBitmap.CopyPixels(pixels, 4, 0);

            // Assuming the image is in RGBA format
            return Color.FromArgb(pixels[3], pixels[2], pixels[1], pixels[0]);
        }
        /*private void DetermineBackgroundColor()
        {
            BitmapImage bitmap = new BitmapImage(new Uri("C:\\Users\\Родион\\source\\repos\\WpfApp1\\WpfApp1\\img\\roadmap.png", UriKind.Relative));

            // Make sure the image is loaded
            bitmap.DownloadCompleted += (s, e) =>
            {
                // Reading the color of the top-left pixel as the background color
                Color backgroundColor = GetColorFromImage(bitmap, 0, 0);

                // Set the background color to a WPF control, such as the window's background
                MainWindow.Background = new SolidColorBrush(backgroundColor);
            };
        }*/
    }
}
