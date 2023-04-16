using ActioRusApp.Classes;
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

namespace ActioRusApp
{
    /// <summary>
    /// Логика взаимодействия для LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        private int attemps = 0;
        Random _random = new Random();
        private TextBlock myTextBlock;
        public LogInPage()
        {
            InitializeComponent();
            Classes.Dbconnect.dbconnect = new Models.ActioRusBDEntities();
        }
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Password))
            {
                MessageBox.Show("Для начала, введите пароль!", "Уведомление");

                CheckBoxPass.IsChecked = false;
            }
            else
            {
                TxbPassword.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Collapsed;
                TxbPassword.Text = Password.Password;
            }


        }
        private void CheckBox_UnChecked(object sender, RoutedEventArgs e)
        {

            TxbPassword.Visibility = Visibility.Collapsed;
            Password.Visibility = Visibility.Visible;
            TxbPassword.Text = Password.Password;

        }
        private void LogIN()
        {
            try
            {
                var userObj = Classes.Dbconnect.dbconnect.Users.FirstOrDefault(x => x.Login == LoginTB.Text && x.Password == Password.Password);


                if (userObj != null)
                {
                    Models.ActioRusBDEntities.currentuser = userObj;
                    MessageBox.Show("Здравствуйте " + userObj.Roles.RoleName + ", " + userObj.Login, "Warning", MessageBoxButton.OK, MessageBoxImage.Information);

                    switch (userObj.RoleID)
                    {
                        case 1:
                            Manager.MainFrame.Navigate(new AdminPage());
                            break;
                        case 2:
                            Manager.MainFrame.Navigate(new ManagerPage());
                            break;
                        case 3:
                            Manager.MainFrame.Navigate(new ClientPage());




                            break;

                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }

                }
                else
                {
                    MessageBox.Show("Не верный логин или пароль", "Уведовление");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая работа приложения",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userObj = Classes.Dbconnect.dbconnect.Users.FirstOrDefault(x => x.Login == LoginTB.Text && x.Password == Password.Password);

            if (userObj == null)
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка при авторизации",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                attemps++;
                CheckAttemps();
            }
            else
            {
                LogIN();
            }
        }
        private void CheckAttemps()
        {

            if (attemps == 2)
            {

                MessageBox.Show("Слишком много неудачных попыток! Подтвердите, что вы человек", "Не удается войти!", MessageBoxButton.OK, MessageBoxImage.Warning);
                Noises.Visibility = Visibility.Visible;
                SymbolsGen.Visibility = Visibility.Visible;
                GetCapcha.Visibility = Visibility.Visible;
                UpdateCapcha.Visibility = Visibility.Visible;
                ConfirmCapcha.Visibility = Visibility.Visible;
                LoginTB.Visibility = Visibility.Collapsed;
                Password.Visibility = Visibility.Collapsed;
                GenerateNoisesForCapcha(30);
                GenerateSymbols(3);
                if (GetCapcha.Text != Symbols)
                {
                }


            }
            else
            {
                if (attemps == 3)
                {
                    MessageBox.Show("Возможность входа заблокирована", "Слишком много неудачных попыток", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Blocked.Visibility = Visibility.Visible;

                    // Блокируем элементы интерфейса
                    foreach (UIElement element in UIInt.Children)
                    {
                        if (element is Control control && control.Name != "ExitButton" && control.Name != "SupportButton")
                        {
                            control.IsEnabled = false;
                        }
                    }

                    // Запускаем таймер на 10 секунд
                    double seconds = 10;
                    DispatcherTimer timer = new DispatcherTimer();
                    timer.Interval = TimeSpan.FromSeconds(1);
                    timer.Tick += (sender, args) =>
                    {
                        seconds--;
                        TimerTextBlock.Text = $"Попробуйте снова через {seconds} сек.";
                        if (seconds == 0)
                        {
                            timer.Stop();
                            Blocked.Visibility = Visibility.Collapsed;
                            TimerTextBlock.Visibility = Visibility.Collapsed;
                            // Разблокируем элементы интерфейса
                            foreach (UIElement element in UIInt.Children)
                            {
                                if (element is Control control && control.Name != "ExitButton" && control.Name != "SupportButton")
                                {
                                    control.IsEnabled = true;
                                    attemps = 0;
                                }
                            }
                        }
                    };
                    timer.Start();
                    TimerTextBlock.Visibility = Visibility.Visible;








                }
            }
        }
        private void GenerateNoisesForCapcha(int volumeNoise)
        {
            Noises.Visibility = Visibility.Visible;
            for (int i = 0; i < volumeNoise; i++)
            {
                Ellipse ellipse = new Ellipse
                {
                    Fill = new SolidColorBrush(Color.FromArgb((byte)_random.Next(100, 200),

                     (byte)_random.Next(0, 256),
                     (byte)_random.Next(0, 256),
                     (byte)_random.Next(0, 256)))
                };

                ellipse.Height = ellipse.Width = _random.Next(20, 60);

                Canvas.SetLeft(ellipse, _random.Next(0, 290));
                Canvas.SetTop(ellipse, _random.Next(0, 100));

                Noises.Children.Add(ellipse);
            }
        }
        public string Symbols = "";
        private void GenerateSymbols(int count)
        {
            string alphabet = "ABCDEFGHJKLMN123456789";
            for (int i = 0; i < count; i++)
            {
                string symbol = alphabet.ElementAt(_random.Next(0, alphabet.Length)).ToString();
                TextBlock lbl = new TextBlock();



                lbl.Text = symbol;
                lbl.FontSize = _random.Next(20, 40);
                lbl.RenderTransform = new RotateTransform(_random.Next(-45, 45));
                lbl.Margin = new Thickness(20, 20, 20, 20);





                Noises.Visibility = Visibility.Visible;
                SymbolsGen.Children.Add(lbl);
                Symbols = Symbols + symbol;
                myTextBlock = lbl;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Symbols = "";
            SymbolsGen.Children.Clear();
            Noises.Children.Clear();

            GenerateSymbols(3);
            GenerateNoisesForCapcha(25);

        }


    }
}

