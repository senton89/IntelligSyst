using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.RoadElements
{
    class Pedestrians : Elements
    {
        Image place;
        public Pedestrians(Image place)
        {
            this.place = place;
        }
        public async void WalkBottom(double coordinates)
        {
            while (true)
            {
                for (int i = 0; i < 60; i++)
                {
                    Canvas.SetBottom(place, coordinates + i);
                    await Task.Delay(66);
                }
            
            for (int i = 0; i < 60; i++)
                {
                    Canvas.SetBottom(place, coordinates + 60 - i);
                    await Task.Delay(66);
                }
            }
        }
        public async void WalkTop(double coordinates)
        {
            while (true)
            {
                for (int i = 0; i < 60; i++)
                {
                    Canvas.SetTop(place, coordinates - i);
                    await Task.Delay(66);
                }
            
            for (int i = 0; i < 60; i++)
                {
                    Canvas.SetTop(place, coordinates - 60 + i);
                    await Task.Delay(66);
                }
            }
        }
        public async void WalkRight(double coordinates)
        {
            while (true)
            {
                for (int i = 0; i < 60; i++)
                {
                    Canvas.SetRight(place, coordinates - i);
                    await Task.Delay(66);
                }
            
            for (int i = 0; i < 60; i++)
                {
                    Canvas.SetRight(place, coordinates - 60 + i);
                    await Task.Delay(66);
                }
            }
        }
        public async void WalkLeft(double coordinates)
        {
            while (true)
            {
                for (int i = 0; i < 60; i++)
                {
                    Canvas.SetLeft(place, coordinates + i);
                    await Task.Delay(66);
                }
            
            for (int i = 0; i < 60; i++)
                {
                    Canvas.SetLeft(place, coordinates + 60 - i);
                    await Task.Delay(66);
                }
            }
        }
    }
}
