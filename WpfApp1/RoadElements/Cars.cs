using System;
using System.Collections.Generic;
using System.Configuration;
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
        public Image place;
        private RotateTransform rotateTransform = new RotateTransform();
        private TranslateTransform translateTransform = new TranslateTransform();
        private int startAngle = 0;

        public Cars(Image place)
        {
            this.place = place;
            place.Source = GetBitmapImage("car");
        }
        public void MoveBottom(int Ycoordinates, int pixels = 20)
        {
            //place.RenderTransform = new RotateTransform(startAngle);
            //place.RenderTransform = translateTransform;

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.To = Ycoordinates + pixels;
            moveAnimation.Duration = new Duration(TimeSpan.FromSeconds(1)); // Продолжительность анимации в секундах
            place.BeginAnimation(Canvas.TopProperty, moveAnimation);
        }
        public void MoveTop(int Ycoordinates, int pixels = 20)
        {
            //place.RenderTransform = new RotateTransform(startAngle);
            //place.RenderTransform = translateTransform;

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.To = Ycoordinates - pixels;
            moveAnimation.Duration = new Duration(TimeSpan.FromSeconds(1)); // Продолжительность анимации в секундах
            place.BeginAnimation(Canvas.TopProperty, moveAnimation);
        }
        public void MoveLeft(int Xcoordinates, int pixels = 20)
        {
            //place.RenderTransform = new RotateTransform(startAngle);
            //place.RenderTransform = translateTransform;

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.To = Xcoordinates - pixels;
            moveAnimation.Duration = new Duration(TimeSpan.FromSeconds(1)); // Продолжительность анимации в секундах
            place.BeginAnimation(Canvas.LeftProperty, moveAnimation);
        }
        public void MoveRight(int Xcoordinates, int pixels = 20)
        {

            //place.RenderTransform = new RotateTransform(startAngle);
            //place.RenderTransform = translateTransform;

            DoubleAnimation moveAnimation = new DoubleAnimation();
            moveAnimation.To = Xcoordinates + pixels;
            moveAnimation.Duration = new Duration(TimeSpan.FromSeconds(1)); // Продолжительность анимации в секундах
            place.BeginAnimation(Canvas.LeftProperty, moveAnimation);
        }
        public async void TurnBottomToLeft(int Xcoordinates, int Ycoordinates)
        {
            MoveTop(Ycoordinates, 40);
            await Task.Delay(500);
            RotateLeft(90);
            await Task.Delay(100);
            MoveLeft(Xcoordinates, 40);
        }
        public async void TurnBottomToRight(int Xcoordinates, int Ycoordinates)
        {
            MoveTop(Ycoordinates, 20);
            await Task.Delay(200);
            RotateRight(90);
            await Task.Delay(100);
            MoveRight(Xcoordinates, 20);
        }
        public async void TurnTopToRight(int Xcoordinates, int Ycoordinates)
        {
            startAngle = 180;
            MoveBottom(Ycoordinates, 40);
            await Task.Delay(350);
            RotateLeft(90);
            await Task.Delay(450);
            MoveRight(Xcoordinates, 40);
        }
        public async void TurnTopToLeft(int Xcoordinates, int Ycoordinates)
        {
            startAngle = 180;
            MoveBottom(Ycoordinates, 20);
            await Task.Delay(400);
            RotateRight(90);
            await Task.Delay(300);
            MoveLeft(Xcoordinates, 20);
        }
        public async void TurnRightToBottom(int Xcoordinates, int Ycoordinates)
        {
            startAngle = 270;
            RotateLeft(0);
            MoveLeft(Xcoordinates, 40);
            await Task.Delay(500);
            RotateLeft(90);
            await Task.Delay(100);
            MoveBottom(Ycoordinates, 40);
        }
        public async void TurnRightToTop(int Xcoordinates, int Ycoordinates)
        {
            startAngle = 270;
            RotateRight(1);
            MoveLeft(Xcoordinates, 20);
            await Task.Delay(200);
            RotateRight(90);
            await Task.Delay(100);
            MoveTop(Ycoordinates, 20);
        }
        public async void TurnLeftToBottom(int Xcoordinates, int Ycoordinates)
        {
            startAngle = 90;
            RotateLeft(1);
            MoveRight(Xcoordinates, 20);
            await Task.Delay(500);
            RotateRight(90);
            await Task.Delay(100);
            MoveBottom(Ycoordinates, 20);
        }
        public async void TurnLeftToTop(int Xcoordinates, int Ycoordinates)
        {
            startAngle = 270;
            RotateRight(1);
            MoveLeft(Xcoordinates, 20);
            await Task.Delay(200);
            RotateRight(90);
            await Task.Delay(100);
            MoveTop(Ycoordinates, 20);
        }

        public void RotateRight(int angle)
        {
            
            place.RenderTransformOrigin = new Point(0.5, 0.5);
            place.RenderTransform = rotateTransform;
            DoubleAnimation rotateAnimation = new DoubleAnimation();
            rotateAnimation.From = startAngle;

            rotateAnimation.To = startAngle + angle;
            rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(1));
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }
        public void RotateLeft(int angle,int seconds = 1)
        {
            place.RenderTransformOrigin = new Point(0.5, 0.5);
            place.RenderTransform = rotateTransform;
            DoubleAnimation rotateAnimation = new DoubleAnimation();
            rotateAnimation.From = startAngle;
            
            rotateAnimation.To = startAngle - angle;
            rotateAnimation.Duration = new Duration(TimeSpan.FromSeconds(seconds));
            rotateTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnimation);
        }
    }
}