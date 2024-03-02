using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Image = System.Windows.Controls.Image;

namespace WpfApp1
{
    public class ComboBoxItem
    {
        public Image image = new Image();
        public string text; 
        public ComboBoxItem(string imageSource,string text)
        {
            image.Source = RoadElements.Elements.GetBitmapImage(imageSource);
            image.MaxHeight = 16;
            image.MaxWidth = 16;

            this.text = text;
        }
    }
}
