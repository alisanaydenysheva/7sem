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

namespace WitcherTours.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {

        Random _random = new Random();

        public AddEditPage()
        {
            InitializeComponent();
            Classes.DbConnect.modeldb = new Models.HotelsDBEntities();

            UpdateCaptcha();
        }

        private void UpdateCaptcha()
        {
            Symbols = "";
            SPanelSymbols.Children.Clear();
            CanvasNoise.Children.Clear();



            GenerateSymbols(3);
            GenerateNoise(30);
        }

        public string Symbols = "";




        private void GenerateSymbols(int count)
        {
            string alphabet = "WERPASFHKXVBM234578";
            for (int i = 0; i < count; i++)
            {
                string symbol = alphabet.ElementAt(_random.Next(0, alphabet.Length)).ToString();
                TextBlock lbl = new TextBlock();



                lbl.Text = symbol;
                lbl.FontSize = _random.Next(20, 40);
                lbl.RenderTransform = new RotateTransform(_random.Next(-45, 45));
                lbl.Margin = new Thickness(20, 20, 20, 20);



                //lbl.Foreground = ra



                SPanelSymbols.Children.Add(lbl);

                Symbols = Symbols + symbol;
            }
        }



        private void GenerateNoise(int volumeNoise)
        {
            for (int i = 0; i < volumeNoise; i++)
            {
                Border border = new Border();
                border.Background = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256)));
                border.Height = _random.Next(2, 10);
                border.Width = _random.Next(10, 400);



                border.RenderTransform = new RotateTransform(_random.Next(0, 360));

                CanvasNoise.Children.Add(border);
                Canvas.SetLeft(border, _random.Next(0, 300));
                Canvas.SetTop(border, _random.Next(0, 150));


                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256),
                                                                       (byte)_random.Next(0, 256)));
                ellipse.Height = ellipse.Width = _random.Next(20, 40);

                CanvasNoise.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, _random.Next(0, 300));
                Canvas.SetTop(ellipse, _random.Next(0, 150));
            }
        }




        private void Login(object sender, RoutedEventArgs e)
        {
            try
            {
                //Обратиться к таблице User, чтобы извлечь логин и пароль
                //var - общий тип
                //userObj - имя обьекта 
                //Информация об агенте - agentObj
                //папка, класс, модель, таблица
                //сравнить данные из таблицы и названия столбцов логин и пароль
                //Имена текстблоков с их функция текст и пароль
                //&& - И пользователь доллжен ввести и логин и пароль, иначе ошибка

                var userObj = Classes.DbConnect.modeldb.Users.FirstOrDefault(x =>
                x.Login == LoginUs.Text && x.Password == Password.Password);

                /*if(LoginUs.Text=="test" && Password.Password=="test")
                {
                 //Manager.MainFrame.Navigate(new Administrator());
                }*/

                if (userObj != null && (GetCapcha.Text == Symbols))
                {
                    Models.HotelsDBEntities.currentuser = userObj;
                    MessageBox.Show("Здравствуйте " + userObj.Role.Title + ", " + userObj.Login, "Уведомление",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    switch (userObj.ID)
                    {
                        case 1:
                            NavigationService.Navigate(new Administrator());
                            break;
                        case 2:
                            NavigationService.Navigate(new Mangerrr());
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
                else MessageBox.Show("Пользователя в БД нет", "Уведомление");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая работа приложения",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TbxShowPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Collapsed;
            TxbPassword.Text = Password.Password;
        }

        private void TbxShowPass_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Collapsed;
            Password.Visibility = Visibility.Visible;
        }
   

        private void BtnUpdateCaptcha_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
        }
    }
}
