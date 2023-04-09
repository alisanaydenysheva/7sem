using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {

        Random _random = new Random();
        private int attemps = 0;
        private TextBlock myTextBlock;
        
        TimeSpan duration;
        DispatcherTimer timer = new DispatcherTimer();
        DateTime date = new DateTime(0, 0);
        public AddEditPage()
        {
            InitializeComponent();
            Classes.DbConnect.modeldb = new Models.BlagodatEntities2();

            
            CanvasNoise.Visibility = Visibility.Collapsed;
            GetCapcha.Visibility = Visibility.Collapsed;
        }
        /// <summary>
        /// Логика Логика обновления капчи
        /// </summary>
        private void UpdateCaptcha()
        {
            Symbols = "";
            SPanelSymbols.Children.Clear();
            CanvasNoise.Children.Clear();



            GenerateSymbols(3);
            GenerateNoise(30);
        }

        public string Symbols = "";



        /// <summary>
        /// Логика генерации символов для капчи
        /// </summary>
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
                
                

               



                SPanelSymbols.Children.Add(lbl);

                Symbols = Symbols + symbol;
                myTextBlock = lbl;
            }
        }


        /// <summary>
        /// Генерация шумов для капчи
        /// </summary>
        private void GenerateNoise(int volumeNoise)
        {
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

                CanvasNoise.Children.Add(ellipse);
            }
        }
        private void HideSymbols()
        {
            foreach (var child in SPanelSymbols.Children)
            {
                if (child is TextBlock textBlock)
                {
                    // Скрыть текстовый блок
                    textBlock.Visibility = Visibility.Collapsed;

                    // Удалить текстовый блок
                    // SPanelSymbols.Children.Remove(textBlock);
                }
            }
        }
        private void CheckAttemps()
        {

            if (attemps == 2)
            {
                CanvasNoise.Visibility = Visibility.Visible;
                GetCapcha.Visibility = Visibility.Visible;
                CheckCaptcha.Visibility = Visibility.Visible;
                UpdateCaptcha();
                MessageBox.Show("Подтвердите что вы человек", "Не удается войти!", MessageBoxButton.OK, MessageBoxImage.Warning);

                if (GetCapcha.Text != Symbols)
                {
                    LoginUs.Visibility = Visibility.Hidden;
                    Password.Visibility = Visibility.Hidden;

                }
                else LoginUs.Visibility = Visibility.Visible;
            }
            else
            {
                if (attemps == 3)
                {


                    TimeTB.Visibility = Visibility.Visible;
                   
                    BlockedTB.Text = "Слишком много неудачных попыток входа.\nВозможность входа заблокирована на 10 секунд.";
                    CanvasNoise.Visibility = Visibility.Hidden;
                    GetCapcha.Visibility = Visibility.Hidden;
                    CheckCaptcha.Visibility = Visibility.Hidden;
                    HideSymbols();
                    myTextBlock.Visibility = Visibility.Hidden;
                    
                    timer.Interval = TimeSpan.FromSeconds(1);
                    timer.Tick += timerTick;
                    timer.Start();

                }

            }
        }
        private void timerTick(object sender, EventArgs e)
        {



            date = date.AddSeconds(1);
            TimeTB.Text = date.ToString("HH:mm:ss");

            if (TimeTB.Text == "00:00:10")
            {
                MessageBox.Show("Вы можете повторить попытку входа!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
                CanvasNoise.Visibility = Visibility.Hidden;
                GetCapcha.Visibility = Visibility.Hidden;
                CheckCaptcha.Visibility = Visibility.Hidden;
                LoginUs.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Visible;
                HideSymbols();
                myTextBlock.Visibility = Visibility.Visible;
                LoginUs.Visibility = Visibility.Visible;
                TimeTB.Visibility = Visibility.Hidden;
                BlockedTB.Text = "";
                LoginUs.IsEnabled = true;
            }
            
        }
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Login(sender, e);
            }
        }

        private void LogIN()
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

                var userObj = Classes.DbConnect.modeldb.User.FirstOrDefault(x =>
                x.Login == LoginUs.Text && x.Password == Password.Password);

                /*if(LoginUs.Text=="test" && Password.Password=="test")
                {
                 //Manager.MainFrame.Navigate(new Administrator());
                }*/

                if (userObj != null )
                {
                    Models.BlagodatEntities2.currentuser = userObj;
                    MessageBox.Show("Здравствуйте " + userObj.Role.Title + ", " + userObj.Login, "Уведомление",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                    switch (userObj.RoleID)
                    {
                        case 1:
                            NavigationService.Navigate(new ClientsPage());
                            break;
                        case 2:
                            NavigationService.Navigate(new Mangerrr());
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
                else MessageBox.Show("Не верный логин или пароль", "Уведомление");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message.ToString(), "Критическая работа приложения",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



        /// <summary>
        /// Обработка нажатия кнопки "Войти"
        /// </summary>
        private void Login(object sender, RoutedEventArgs e)
        {
            var userObj = Classes.DbConnect.modeldb.User.FirstOrDefault(x =>
                  x.Login == LoginUs.Text && x.Password == Password.Password);
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
        /// <summary>
        /// Функция отвечает за возможность показать пароль
        /// </summary>
        private void TbxShowPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Collapsed;
            TxbPassword.Text = Password.Password;
        }

        private void CheckCaptcha_Click(object sender, RoutedEventArgs e)
        {
            if (GetCapcha.Text == Symbols)
                LoginUs.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Visible;
        }
        /// <summary>
        /// Пароль скрывается
        /// </summary>
        private void TbxShowPass_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Collapsed;
            Password.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Обновление капчи
        /// </summary>
        private void BtnUpdateCaptcha_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
        }
        /// <summary>
        /// Обработка кнопки регистрации
        /// </summary>
        private void RegButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }

        

        private void ShowPass_Click_1(object sender, RoutedEventArgs e)
        {
            if(TxbPassword.Visibility == Visibility.Collapsed)
            {
                ShowPass.Visibility = Visibility.Collapsed;
                HidePass.Visibility = Visibility.Visible;
                TxbPassword.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Collapsed;
                TxbPassword.Text = Password.Password;
            }
            else
            {
                TxbPassword.Visibility = Visibility.Collapsed;
                Password.Visibility = Visibility.Visible;
            }
            
        }
        private void HidePass_Click1(object sender, RoutedEventArgs e)
        {
            if (TxbPassword.Visibility == Visibility.Collapsed)
            {
                ShowPass.Visibility = Visibility.Collapsed;
                HidePass.Visibility = Visibility.Visible;
                TxbPassword.Visibility = Visibility.Visible;
                Password.Visibility = Visibility.Collapsed;
                TxbPassword.Text = Password.Password;
            }
            else
            {
                TxbPassword.Visibility = Visibility.Collapsed;
                Password.Visibility = Visibility.Visible;
                HidePass.Visibility = Visibility.Collapsed;
                ShowPass.Visibility = Visibility.Visible;
            }
        }
    }
}
