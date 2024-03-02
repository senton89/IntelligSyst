using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1.RoadElements
{
    class Routes
    {
        List<Image> images = new List<Image>();
        static MainWindow main = new MainWindow();
        private void MoveAndCheck(Cars car)
        {
            int.TryParse(main.mouseMoverX.Content.ToString(), out int x);
            int.TryParse(main.mouseMoverY.Content.ToString(), out int y);
            car.MoveLeft((x - 1) * 20, (y - 1) * 20 + 5);
        }
        public static async void carRoute(Cars car,int x,int y)
        {
            car.RotateLeft(90, 0);
            car.MoveLeft(x,40);
            await Task.Delay(1000);
            car.TurnRightToBottom(x - 40, y);
            await Task.Delay(1600);
            car.MoveBottom(y + 40, 40);
            await Task.Delay(1000);
            car.MoveBottom(y + 80, 40);
            await Task.Delay(1000);
            car.MoveBottom(y + 120, 40);
            await Task.Delay(1000);
            car.TurnTopToRight(x - 80, y + 160);
            await Task.Delay(1600);
            car.MoveRight(x-40, 40);
        }
        public static async void carDispose(Cars car,MainWindow mainWindow)
        {
            await Task.Delay(8400);
            mainWindow.MainCanvas.Children.Remove(car.place);           
        }
    }
}
