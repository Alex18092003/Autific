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

namespace Autific.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuthorization.xaml
    /// </summary>
    public partial class PageAuthorization : Page
    {
        public PageAuthorization()
        {
            InitializeComponent();
        }
        string login = "111";
        string password = "111";

        private void buttonAuthorization_Click(object sender, RoutedEventArgs e)
        {
            if(textLogin.Text == login)
            {
                if(tsxtPassword.Text == password)
                {
                    Random rnd = new Random();
                    int numbers = rnd.Next(10000, 99999);
                    MessageBox.Show($"Ваш числовой код : {numbers}\nПожалуйста, запомните его!", "Информация");
                    Windows.WindowKod windowKod = new Windows.WindowKod();
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
    }
}
