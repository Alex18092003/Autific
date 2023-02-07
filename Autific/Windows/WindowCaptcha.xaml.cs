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
        string text = String.Empty;
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
            text = String.Empty;
            string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            for (int i = 0; i < k; i++)
            {
                text += chars[rnd.Next(chars.Length)];

            }
            int h;
            int w;
            for (int i = 0; i < text.Length; i++)
            {
                       
                int v = rnd.Next(3);
                        if (v == 0)
                        {
                            int font = rnd.Next(16, 30);
                           // h = rnd.Next((int)canv.Height - 70);
                           // w = rnd.Next((int)canv.Width - 70);
                            TextBlock textBlock = new TextBlock()
                            {
                                Text = text[i].ToString(),
                                FontSize = font,
                                FontStyle = FontStyles.Italic,
                                Padding = new Thickness(i*20, rnd.Next(70), rnd.Next(150), 0),
                            };
                            canv.Children.Add(textBlock);
                        }
                        else if (v == 1)
                        {
                            int font = rnd.Next(16, 30);
                            //h = rnd.Next((int)canv.Height - 10);
                            //w = rnd.Next((int)canv.Width - 10);
                            TextBlock textBlock = new TextBlock()
                            {
                                Text = text[i].ToString(),
                                FontSize = font,
                                FontWeight = FontWeights.Bold,
                                Padding = new Thickness(i * 20, rnd.Next(70), rnd.Next(150), 0),
                            };
                            canv.Children.Add(textBlock);
                        }
                        else if (v == 2)
                        {
                            int font = rnd.Next(16, 30);
                           // h = rnd.Next((int)canv.Height - 10);
                             //w = rnd.Next((int)canv.Width - 10);
                            TextBlock textBlock = new TextBlock()
                            {
                                Text = text[i].ToString(),
                                FontSize = font,
                                FontWeight = FontWeights.Bold,
                                FontStyle = FontStyles.Italic,
                                Padding = new Thickness(i * 20, rnd.Next(70), rnd.Next(150), 0),
                            };
                            canv.Children.Add(textBlock);
                        }
              
            }

        }


        int h = 0;
        private void buttonCaptcha_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //MessageBox.Show($"{text}", "Информация");
                if (textboxCaptcha.Text == text )
                {
                    MessageBox.Show("Успешно", "Информация");
                    this.Close();
                }
                else if (h == 0)
                {
                    h = h + 1;
                    MessageBox.Show("Попробуйте еще раз", "Информация");
                }
                else
                {
                    MessageBox.Show("Провал!", "Информация");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так с кнопкой", "Ошибка");
            }
        }
    }
}
