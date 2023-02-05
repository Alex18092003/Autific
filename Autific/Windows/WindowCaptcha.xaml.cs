using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Autific.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowCaptcha.xaml
    /// </summary>
    public partial class WindowCaptcha : Window
    {
       
        public WindowCaptcha()
        {
            InitializeComponent();
            Random rnd = new Random();
            for(int i =0; i <11; i++)
            {
                SolidColorBrush brush = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(256), (byte)rnd.Next(256), (byte)rnd.Next(256)));
                Line line = new Line()
                {
                    X1 = rnd.Next((int)canv.Width),
                    Y1 = rnd.Next((int)canv.Height),
                    X2 = rnd.Next((int)canv.Width),
                    Y2 = rnd.Next((int)canv.Height),
                    Stroke = brush,
                };
                canv.Children.Add(line);
            }

            int k = rnd.Next(7, 11);
            for (int i = 0; i < k;i ++)
            {

            }

            


        }
    }
}
