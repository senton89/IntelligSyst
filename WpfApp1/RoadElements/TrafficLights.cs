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
        static int count = 0;
        Image place;
        public TrafficLights(Image place)
        {
            count++;
            this.place = place;
            SqlConnection connection = new SqlConnection(@"Data Source=laptop-9udmbido\sqlexpress; Initial Catalog=IntelligSyst
; Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand($"INSERT INTO trafficLights (Id_light) values ({count})", connection);
            command.ExecuteNonQuery();
            connection.Close();
            SwitchLight();
        }
        ~TrafficLights() {
            SqlConnection connection = new SqlConnection(@"Data Source=laptop-9udmbido\sqlexpress; Initial Catalog=IntelligSyst
; Integrated Security=True");
            connection.Open();
            SqlCommand command = new SqlCommand($"Delete from trafficLights where (Id_light = {count});", connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        public async void SwitchLight()
        {
            while (true)
            {
                place.Source = this.GetBitmapImage("trafficLightRed", place);
                await Task.Delay(1000);
                place.Source = this.GetBitmapImage("trafficLight", place);
            }
        }
    }
}
