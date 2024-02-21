using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.RoadElements
{
    class TrafficLights : Elements
    {
        Image place;
        public TrafficLights(Image place)
        {
            this.place = place;
            DrawElement("trafficLight", place, 10, 10);
        }
    }
}
