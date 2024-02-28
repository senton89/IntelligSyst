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

namespace WpfApp1.RoadElements
{
    class TrafficLights : Elements
    {
        static List<TrafficLights> lights = new List<TrafficLights>();
        static int count = 0;
        static SqlConnection connection = new SqlConnection(@"Data Source=laptop-9udmbido\sqlexpress; Initial Catalog=IntelligSyst
; Integrated Security=True");
        int code { get; }
        Image place;
        public TrafficLights(Image place)
        {
            count++;
            code = count;
            this.place = place;
            //place.Name = "trafficLight" + code.ToString();           
            connection.Open();
            SqlCommand command = new SqlCommand($"INSERT INTO trafficLights (Id_light) values ({code})", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        ~TrafficLights() {
            SqlConnection connection = new SqlConnection(@"Data Source=laptop-9udmbido\sqlexpress; Initial Catalog=IntelligSyst
; Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand($"Delete from trafficLights where (Id_light = {code});", connection);
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
        }
        private static async void SwitchLight(TrafficLights TrafficLight)
        {
            while (true)
            {
                TrafficLight.place.Source = GetBitmapImage("trafficLightRed");
                await Task.Delay(5000);
                TrafficLight.place.Source = GetBitmapImage("trafficLightGreen");
                await Task.Delay(5000);
            }
        }
    }
}
