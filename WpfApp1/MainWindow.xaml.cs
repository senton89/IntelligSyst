using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.RoadElements;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            RoadMap map = new RoadMap(RoadMap);
            MouseMove += Window_MouseMove;
            List<string> elements = new List<string> {
                "Пешеходный переход","Пешеход",
                "Знак стоп","Проезд автомобилям с прицепам воспрещен",
                "Проезд грузовым автомобилям воспрещен","Светофор"
            };
            ElementsCMB.ItemsSource = elements;
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(this);
            if (position.X < 0 || position.X >= 400 || position.Y < 40 || position.Y >= 440)
            {
                mouseMover.Content = "";
                return;
            }
            mouseMover.Content = $"X: {1+(int)position.X / 20}, Y: {(int)position.Y / 20 - 1}";
        }

        private void ElementsCMB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = ElementsCMB.SelectedValue.ToString();
            switch (selectedItem)
            {
                case "Пешеходный переход":

                    break;
                case "Пешеход":
                    break;
                case "Светофор":
                    break;
                case "Знак стоп":
                    StopSigns sign = new StopSigns(StopSign);
                    break;
            }
        }
    }
}
