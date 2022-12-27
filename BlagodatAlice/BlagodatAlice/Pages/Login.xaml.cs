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
using BlagodatAlice.Classes;
using BlagodatAlice.Models;

namespace BlagodatAlice.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        Random _random = new Random();
        public Login()
        {
            InitializeComponent();
            UpdateCaptcha();
            ConnectDBClass.modelDB = new Models.BlagodatAliceEntities();
        }

        private void UpdateCaptcha()
        {
            symbols = "";
            SPanelSymbols.Children.Clear();
            CanvasNoise.Children.Clear();



            GenerateSymbols(4);
            GenerateNoise(30);
        }
        public string symbols;
        private void GenerateSymbols(int count)
        {
            string alphabet = "WERPASFHKXVBM234578";
            for (int i = 0; i < count; i++)
            {
                string symbol = alphabet.ElementAt(_random.Next(0, alphabet.Length)).ToString();
                TextBlock lbl = new TextBlock();



                lbl.Text = symbol;
                lbl.FontSize = _random.Next(40, 80);
                lbl.RenderTransform = new RotateTransform(_random.Next(-45, 45));
                lbl.Margin = new Thickness(10, 0, 10, 0);
                SPanelSymbols.Children.Add(lbl);
                symbols = symbols + symbol;
            }
        }



        private void GenerateNoise(int volumeNoise)
        {
            volumeNoise = 10;
            for (int i = 0; i < volumeNoise; i++)
            {
                Border border = new Border();
                border.Background = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256)));
                border.Height = _random.Next(2, 5);
                border.Width = _random.Next(10, 50);



                border.RenderTransform = new RotateTransform(_random.Next(0, 360));






                CanvasNoise.Children.Add(border);
                Canvas.SetLeft(border, _random.Next(40, 300));
                Canvas.SetTop(border, _random.Next(10, 100));















                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),//случайный выбор цветов
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256)));
                ellipse.Height = ellipse.Width = _random.Next(20, 40);



                CanvasNoise.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, _random.Next(0, 300));//разбросс кружков по ширине
                Canvas.SetTop(ellipse, _random.Next(10, 50));//разбросс кружков по высоте
            }
        }
        private void BtnUpdateCaptcha_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
        }
        private void LoginButton(object sender, RoutedEventArgs e)
        {
            try
            {
                // обратиться к таблице User, чтобы извлечь логин  пароль
                // var - общий тип переменной
                // userObj - имя объектаБ которого вы задаете сами. Информация об агенте - agentObj
                //Сравнить данные из таблицы и назвыния столбцов
                var userObj = ConnectDBClass.modelDB.User.FirstOrDefault(x =>
                x.Name == textboxLogin.Text && x.Password == PassBox.Password);
                if (userObj != null && (CaptchaGet.Text == symbols))
                {

                    BlagodatAliceEntities.CurentStaff = userObj;
                    switch (userObj.RoleID)
                    {
                        case 1:
                            NavigationService.Navigate(new Admin());
                            break;
                        case 2:
                            NavigationService.Navigate(new User());
                            break;
                        case 3:
                            NavigationService.Navigate(new Admin());
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
                else
                {

                    MessageBox.Show("Такого пользователя нет или капча введена некорректно!", "Ошибка при авторизации",
                   MessageBoxButton.OK, MessageBoxImage.Error);


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая работа приложения",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TbxShowPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Width = PassBox.Width;
            TxbPassword.Visibility = Visibility.Visible;
            PassBox.Visibility = Visibility.Collapsed;
            TxbPassword.Text = PassBox.Password;
        }

        private void TbxShowPass_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Collapsed;
            PassBox.Visibility = Visibility.Visible;
        }
    }
}
