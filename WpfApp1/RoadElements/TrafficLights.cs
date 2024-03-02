using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Xml.Linq;
using System.Threading;
using System.Reflection.Emit;
using Label = System.Windows.Controls.Label;
using System.Windows.Media;

namespace WpfApp1.RoadElements
{
    class TrafficLights : Elements
    {
        static public List<TrafficLights> lights = new List<TrafficLights>();
        public static Button TimerPlus = new();
        public static Button TimerMinus = new();
        public static Label timerValue = new();
        static int count = 0;
        int timer = 5;
        static SqlConnection connection = new SqlConnection(@"Data Source=laptop-9udmbido\sqlexpress; Initial Catalog=IntelligSyst
; Integrated Security=True");
        int code {get;}
        Image place;
        public TrafficLights(Image place)
        {
            count++;
            code = count;
            this.place = place;
            place.Name = "trafficLight" + code.ToString();
            connection.Open();
            SqlCommand command = new SqlCommand($"INSERT INTO trafficLights values ({code},0,0,0)", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        public static void DeleteTrafficLight(int code) {
            connection.Open();
            SqlCommand command = new SqlCommand($"Delete from trafficLights where Id_light = {code};", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public static void AddToList(TrafficLights trafficLight)
        {
            lights.Add(trafficLight);
        }
        public static void AutoSwitchLight()
        {
            foreach (var item in lights)
            {
                SwitchLight(item);
            }
            SwitchDbLight();
        }
        private static async void SwitchLight(TrafficLights trafficLight)
        {           
            
            while (MainWindow.countSwitcher % 2 == 1)
            {
                trafficLight.place.Source = GetBitmapImage("trafficLightRed");
                await Task.Delay(trafficLight.timer*1000);

                trafficLight.place.Source = GetBitmapImage("trafficLightGreen");
                await Task.Delay(trafficLight.timer * 1000);
                
            }
        }
        private static async void SwitchDbLight()
        {
            SqlCommand command = new SqlCommand(
                $"UPDATE trafficLights " +
                "SET Count_color_switches = Count_color_switches + 1 ", connection);

            while (MainWindow.countSwitcher % 2 == 1)
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

                await Task.Delay(5000);
            }
        }


        public static void EditTimer(MainWindow main,TrafficLights trafficLight)
        {
            timerValue.Foreground = Brushes.Black;
            timerValue.Width = 100;
            timerValue.Height = 10;
            TimerPlus.Content = "+";
            TimerPlus.FontSize = 20;
            TimerPlus.Width = 70;
            TimerPlus.Height = 30;
            TimerMinus.Content = "-";
            TimerMinus.FontSize = 20;
            TimerMinus.Width = 70;
            TimerMinus.Height = 30;
            TimerPlus.Click += (senser, e) => { 
                trafficLight.timer++; 
                timerValue.Content = trafficLight.timer;
            };
            TimerMinus.Click += (senser, e) => {
                if(trafficLight.timer > 0)
                    trafficLight.timer--;
                timerValue.Content = trafficLight.timer;
            };
            main.MainCanvas.Children.Add(TimerPlus);
            main.MainCanvas.Children.Add(TimerMinus);
            main.MainCanvas.Children.Add(timerValue);
            Canvas.SetLeft(TimerMinus,470);
            Canvas.SetTop(TimerMinus, 120);
            Canvas.SetLeft(TimerPlus,470);
            Canvas.SetTop(TimerPlus, 160);
            Canvas.SetLeft(timerValue,480);
            Canvas.SetTop(timerValue, 100);
        }
    }
}