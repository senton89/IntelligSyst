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
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using WpfApp1.RoadElements;
using System.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Configuration.Provider;
using System.Configuration;
//using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{

    public partial class MainWindow : Window
    {
        string elementType = "";
        Image imageToDelete;
        Elements element = new Elements();
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
            SqlConnection connection = new SqlConnection(@"Data Source=laptop-9udmbido\sqlexpress; Initial Catalog=Examen
; Integrated Security=True");
        }
    private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(this);
            if (position.X < 0 || position.X >= 400 || position.Y < 40 || position.Y >= 440)
            {
                mouseMoverText.Content = "";
                mouseMoverX.Content = "";
                mouseMoverY.Content = "";
                return;
            }
            mouseMoverText.Content = $"X: \t, Y:";
            mouseMoverX.Content = $"{(int)position.X / 20 + 1}";
            mouseMoverY.Content = $"{(int)position.Y / 20 - 1}";
        }

        private void ElementsCMB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = ElementsCMB.SelectedValue.ToString();
            switch (selectedItem)
            {
                case "Пешеходный переход":
                    elementType = "crosswalk";
                    break;
                case "Пешеход":
                    elementType = "pedestrian";
                    break;
                case "Светофор":
                    elementType = "trafficLight";
                    break;
                case "Знак стоп":
                    elementType = "stop";
                    break;
                case "Проезд автомобилям с прицепам воспрещен":
                    elementType = "noTrailers";
                    break;
                case "Проезд грузовым автомобилям воспрещен":
                    elementType = "noTrucks";
                    break;
                default: break;
            }
        }

        private void AddObject(object sender, MouseButtonEventArgs e)
        {
            Image elementPlace = new Image();
            elementPlace.MouseDown += Element_MouseDown;
            elementPlace.Width = 20;
            elementPlace.Height = 20;
            Canvas.SetZIndex(elementPlace, 1);
            MainCanvas.Children.Add(elementPlace);
            int.TryParse(mouseMoverX.Content.ToString(), out int x);
            int.TryParse(mouseMoverY.Content.ToString(), out int y);
            int offset = 20; 
            Canvas.SetLeft(elementPlace, (x - 1) * offset);
            Canvas.SetTop(elementPlace, (y - 1) * offset + 5);
            try
            {
                elementPlace.Source = element.GetBitmapImage(elementType,elementPlace);
            }
            catch { }
            if (elementType == "pedestrian")
            {
                Pedestrians pedestrian = new Pedestrians(elementPlace);
                pedestrian.WalkTop((y - 1) * offset + 5);
            }
            if (elementType == "trafficLight")
            {
                TrafficLights trafficLight = new TrafficLights(elementPlace);
            }
        }
        private void Element_MouseDown(object sender,MouseButtonEventArgs e)
        {
            //TODO click on void = remove Effect
            DeleteObject.IsEnabled = true;
            imageToDelete = (Image)sender;
            foreach (var child in MainCanvas.Children)
            {
                if (child is Image && child!=imageToDelete)
                {
                    (child as Image).Effect = null;
                }
            }

            (sender as Image).Effect = new DropShadowEffect()
            {
                Color = Colors.Yellow,
                Direction = 320,
                BlurRadius = 25,
                ShadowDepth = 0,
            };
        }

        private void DeleteObject_Click(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Remove(imageToDelete);
            DeleteObject.IsEnabled = false;

        }
    }
}
