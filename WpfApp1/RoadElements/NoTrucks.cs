using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.RoadElements
{
    class NoTrucks : Elements
    {
        Image place;
        public NoTrucks(Image place)
        {
            this.place = place;
            DrawElement("notrucks", place, 10, 10);
        }
    }
}
