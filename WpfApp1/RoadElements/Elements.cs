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
        public static BitmapImage GetBitmapImage(string element)
        {
            string imagePath = $@"C:\Users\Родион\source\repos\WpfApp1\WpfApp1\img\{element}.png";
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();
            
            return bitmap;
        }
    }
}
