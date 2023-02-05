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
using System.Windows.Threading;

namespace Autific.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowKod.xaml
    /// </summary>
    public partial class WindowKod : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        string code;
        int  count = 10;

        public WindowKod(string code)
        {
            InitializeComponent();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += new EventHandler(Back);
            dispatcherTimer.Start();
            this.code = code;
            
        }

        private void Back( object sender, EventArgs e)
        {
            if(count == 0)
            {
                Pages.PageAuthorization.kodd ++;
                this.Close();
                
            }
            else
            {
                textTime.Text = "Оставшееся время " + count + " секунд";
            }
            count--;
        }



        private void textboxKod_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                textboxKod.MaxLength = 5;
                if (textboxKod.MaxLength == 5)
                {
                    if (textboxKod.Text == code)
                    {
                        Pages.PageAuthorization.kodd = 0;
                        MessageBox.Show("Успешный вход", "Информация");
                        this.Close();
                    }
                }
            }
            catch
            { 
                MessageBox.Show("Что-то пошло не так с проверкой кода", "Ошибка");
            }
               
        }

        private void textboxKod_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            try
            {
                if (!(Char.IsDigit(e.Text, 0))) e.Handled = true;
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с запретов ввода символов", "Ошибка");
            }
        }
    }
}
