using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.RoadElements
{
    class StopSigns : Elements
    {
        Image place;
        public StopSigns(Image place)
        {
            this.place = place;
            DrawElement("stop", place, 10, 10);
        }
    }
}
