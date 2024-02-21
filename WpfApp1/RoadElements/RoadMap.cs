using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp1.RoadElements
{
    class RoadMap : Elements
    {
        Image place;
        public RoadMap(Image place)
        {
            this.place = place;
            DrawElement("roadmap", place);
        }
        public void DrawElement(string element, Image name)
        {
            string imagePath = $"C:\\Users\\Родион\\source\\repos\\WpfApp1\\WpfApp1\\img\\{element}.png";

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(imagePath);
            bitmap.EndInit();

            name.Source = bitmap;
        }
    }
}
