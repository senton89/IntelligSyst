using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp1.RoadElements
{
    class TrafficLights : Elements
    {
        Image place;
        public TrafficLights(Image place, int x, int y)
        {
            this.place = place;
            
        }
    }
}
