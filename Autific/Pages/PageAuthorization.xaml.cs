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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Autific.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        string login = "111";
        string password = "111";

        public static int kodd = 0;
        int count = 60;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        public PageAuthorization()
        {
            InitializeComponent();
            

            if(kodd != 0)
            {
               
                buttonAuthorization.IsEnabled = false;
                textLogin.IsEnabled = false;
                tsxtPassword.IsEnabled = false;
                textTime.Visibility = Visibility.Visible;
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Tick += new EventHandler(Back);
                dispatcherTimer.Start();
                
            }
        }
        private void Back(object sender, EventArgs e)
        {
            if (count == 0)
            {
                buttonNewKod.Visibility = Visibility.Visible;
                dispatcherTimer.Stop();

            }
            else
            {
                textTime.Text = "Получить новый код можно будет через " + count + " секунд";
            }
            count--;
        }



            private void buttonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            if(textLogin.Text == login)
            {
                if(tsxtPassword.Text == password)
                {
                    Random rnd = new Random();
                    int numbers = rnd.Next(10000, 99999);
                    MessageBox.Show($"Ваш числовой код : {numbers}\nПожалуйста, запомните его!", "Информация");
                    Windows.WindowKod windowKod = new Windows.WindowKod(numbers.ToString());
                    windowKod.ShowDialog();
                    Classes.FrameClass.FrameMain.Navigate(new PageAuthorization());
                }
                else
                {
                    MessageBox.Show("Неверный введен пароль", "Ошибка");
                }

            }
            else
            {
                MessageBox.Show("Неверный логин введен", "Ошибка");
            }
        }

        private void buttonNewKod_Click(object sender, RoutedEventArgs e)
        {
            if (kodd != 2)
            {

                Random rnd = new Random();
                int numbers = rnd.Next(10000, 99999);
                MessageBox.Show($"Ваш числовой код : {numbers}\nПожалуйста, запомните его!", "Информация");
                Windows.WindowKod windowKod = new Windows.WindowKod(numbers.ToString());
                windowKod.ShowDialog();
                Classes.FrameClass.FrameMain.Navigate(new PageAuthorization());
            }
            else if(kodd == 2)
            {
                Windows.WindowCaptcha windowKod = new Windows.WindowCaptcha();
                windowKod.ShowDialog();
            }
        }
    }
}
