using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace WpfApp1.RoadElements
{
    class Pedestrians : Elements
    {
        Image place;
        Label label = new();
        public int timer = 0;
        public Pedestrians(Image place,MainWindow main,int x,int y)
        {
            this.place = place;
            label.Content = timer.ToString();
            label.Foreground = Brushes.Blue;
            Canvas.SetLeft(label, x + 2);
            Canvas.SetTop(label, y - 22);
            Canvas.SetZIndex(label, 2);
            main.MainCanvas.Children.Add(label);
            StartTimer();
        }
        public async void StartTimer()
        {
            while (true)
            {
                if (timer <= 1)
                    while (timer < 5)
                    {
                        timer++;
                        label.Content = timer.ToString();
                        await Task.Delay(1000);
                    }
                if (timer >= 5)
                    while (timer > 1)
                    {
                        timer--;
                        label.Content = timer.ToString();
                        await Task.Delay(1000);
                    }
            }
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
