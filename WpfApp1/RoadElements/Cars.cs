using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;


namespace WpfApp1.RoadElements
{
    internal class Cars : Elements
    {
        Image place;
        private RotateTransform rotateTransform = new RotateTransform();
        private TranslateTransform translateTransform = new TranslateTransform();
        private int startAngle = 0;

        public Cars(Image place) {
            this.place = place;
            place.Source = GetBitmapImage("car", place);
        }
        public async void MoveBottom(int Ycoordinates)
        {
            startAngle = 180;
            place.RenderTransform = new RotateTransform(startAngle);
            place.RenderTransform = translateTransform;

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.To = Ycoordinates + 20;
            moveAnimation.Duration = new Duration(TimeSpan.FromSeconds(1)); // Продолжительность анимации в секундах
            place.BeginAnimation(Canvas.TopProperty, moveAnimation);
        }
        public async void MoveTop(int Ycoordinates)
        {
            startAngle = 0;
            place.RenderTransform = new RotateTransform(startAngle);
            place.RenderTransform = translateTransform;

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.To = Ycoordinates + 20;
            moveAnimation.Duration = new Duration(TimeSpan.FromSeconds(1)); // Продолжительность анимации в секундах
            place.BeginAnimation(Canvas.TopProperty, moveAnimation);
        }
        public void MoveLeft(int Xcoordinates)
        {
            startAngle = 270;
            place.RenderTransform = new RotateTransform(startAngle);
            place.RenderTransform = translateTransform;

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.To = Xcoordinates - 20;
            moveAnimation.Duration = new Duration(TimeSpan.FromSeconds(1)); // Продолжительность анимации в секундах
            place.BeginAnimation(Canvas.LeftProperty, moveAnimation);
        }
        public async void MoveRight(int Xcoordinates)
        {
            startAngle = 90;
            place.RenderTransform = new RotateTransform(startAngle);
            place.RenderTransform = translateTransform;

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.To = Xcoordinates + 20;
            moveAnimation.Duration = new Duration(TimeSpan.FromSeconds(1)); // Продолжительность анимации в секундах
            place.BeginAnimation(Canvas.LeftProperty, moveAnimation);
        }
        public void RotateRight()
        {
            place.RenderTransformOrigin = new Point(0.5, 0.5);
            place.RenderTransform = rotateTransform;
            DoubleAnimation rotateAnimation = new DoubleAnimation();
            rotateAnimation.From = startAngle;
            rotateAnimation.To = startAngle + 90;
            rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }
        public void RotateLeft()
        {
            place.RenderTransformOrigin = new Point(0.5, 0.5);
            place.RenderTransform = rotateTransform;
            DoubleAnimation rotateAnimation = new DoubleAnimation();
            rotateAnimation.From = startAngle;
            rotateAnimation.To = startAngle - 90;
            rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }
    }
}
