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
using System.Xml.Serialization;
using System.IO;
//using static System.Net.Mime.MediaTypeNames;

namespace WpfApp1
{
    
    public partial class MainWindow : Window
    {
        public static int countSwitcher = 0;
        public static List<Point> RoadHorizontal = new List<Point>();
        public static List<Point> RoadVertical = new List<Point>();
        string elementType = "";
        static Image imageToDelete;
        public MainWindow()
        {
            InitializeComponent();
            Height = 500;
            Width = 600;
            ResizeMode = ResizeMode.NoResize;
            RoadHorizontal = LoadDictionary("Horizontal");
            RoadVertical = LoadDictionary("Vertical");
            RoadMap map = new RoadMap(RoadMap);
            RoadMap.Source = Elements.GetBitmapImage("roadmap");
            MouseMove += Window_MouseMove;

            // new BitmapImage(new Uri("yourImage.jpg", UriKind.Relative));
            //image.Width = 20;
            //image.Height = 20;
            //TextBlock textBlock = new TextBlock();
            //textBlock.Text = "Динамическая опция";
            //stackPanel.Children.Add(image);
            //stackPanel.Children.Add(textBlock);
            //item.Content = stackPanel;
            //comboBox.Items.Add(item);

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
            //string selectedItem = ElementsCMB.SelectedValue.ToString();
            int selectedItem = ElementsCMB.SelectedIndex+1;
            switch (selectedItem)
            {
                case 1:
                    elementType = "car";
                    break;
                case 2:
                    elementType = "crosswalk";
                    break;
                case 3:
                    elementType = "pedestrian";
                    break;
                case 4:
                    elementType = "stop";
                    break;
                case 5:
                    elementType = "noTrailers";
                    break;
                case 6:
                    elementType = "noTrucks";
                    break;
                case 7:
                    elementType = "trafficLightGreen";
                    break;
                default:
                    break;
            }
        }

        private void AddObject(object sender, MouseButtonEventArgs e)
        {
            Image elementPlace = new();
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
                elementPlace.Source = Elements.GetBitmapImage(elementType);
            }
            catch { }
            if (elementType == "pedestrian")
            {
                Pedestrians pedestrian = new Pedestrians(elementPlace,this, (x - 1) * offset, (y - 1) * offset + 5);
                pedestrian.WalkTop((y - 1) * offset + 5);
            }
            if (elementType == "car")
            {
                Cars car = new Cars(elementPlace);
                Routes.carRoute(car, (x - 1) * offset, (y - 1) * offset + 5);
                Routes.carDispose(car, this);
            }
            if (elementType == "trafficLightGreen")
            {
                TrafficLights trafficLight = new TrafficLights(elementPlace);
                TrafficLights.AddToList(trafficLight);
                TrafficLightMode.IsEnabled = true;
            }
        }
        private void Element_MouseDown(object sender,MouseButtonEventArgs e)
        {
            DeleteObject.IsEnabled = true;
            imageToDelete = (Image)sender;
            foreach (var child in MainCanvas.Children)
            {
                if (child is Image && child != imageToDelete)
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

            if (imageToDelete.Name.Contains("trafficLight"))
            {
                int.TryParse(imageToDelete.Name.Substring(12), out int code);
                TrafficLights.EditTimer(this, TrafficLights.lights[code-1]);
            }
        }

        private void DeleteObject_Click(object sender, RoutedEventArgs e)
        {
            MainCanvas.Children.Remove(imageToDelete);
            if (imageToDelete.Name.Contains("trafficLight"))
            {
                int.TryParse(imageToDelete.Name.Substring(12),out int code);
                TrafficLights.DeleteTrafficLight(code);
            }
            DeleteObject.IsEnabled = false;
        }

        private void TrafficLightMode_Click(object sender, RoutedEventArgs e)
        {
            countSwitcher += 1;
            TrafficLights.AutoSwitchLight();
        }

        public static void SaveDictionary(string type)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Point>));
            using (StreamWriter writer = new StreamWriter($"C:\\Users\\Родион\\source\\repos\\WpfApp1\\WpfApp1\\XML{type}.xml"))
            {
                serializer.Serialize(writer, RoadHorizontal);
            }
        }
        
        public static List<Point> LoadDictionary(string type)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Point>));
            using (StreamReader reader = new StreamReader($"C:\\Users\\Родион\\source\\repos\\WpfApp1\\WpfApp1\\XML{type}.xml"))
            {
                try
                {
                    return (List<Point>)serializer.Deserialize(reader);
                }
                catch{
                    return new List<Point>();
                }
            }
        }
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int.TryParse(mouseMoverX.Content.ToString(), out int x);
            int.TryParse(mouseMoverY.Content.ToString(), out int y);
            //RoadHorizontal.Add(new Point(x, y));
            //RoadVertical.Add(new Point(x, y));
            if (!(e.OriginalSource is Image))
            {
                if (imageToDelete != null)
                {
                    imageToDelete.Effect = null;
                    imageToDelete = new();                
                }
            }
        }
    }
}
