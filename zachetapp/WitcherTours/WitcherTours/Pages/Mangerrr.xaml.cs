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
using WitcherTours.Models;

namespace WitcherTours.Pages
{
    /// <summary>
    /// Логика взаимодействия для Mangerrr.xaml
    /// </summary>
    public partial class Mangerrr : Page

    {
        DispatcherTimer timer = new DispatcherTimer();
        DateTime date = new DateTime(0, 0);
        public Mangerrr()
        {
            InitializeComponent();



            UserTB.Text = HotelsDBEntities.currentuser.Login;
            RoleTB.Text = "(" + HotelsDBEntities.currentuser.Role.Title + ")";

            var fullFilePath = HotelsDBEntities.currentuser.photo;

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri(fullFilePath, UriKind.Relative);
            bitmap.EndInit();

            UserPhoto.Source = bitmap;

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timerTick;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            date = date.AddSeconds(1);
            TimeTB.Text = date.ToString("HH:mm:ss");

            if (TimeTB.Text == "00:00:10")
            {
                MessageBox.Show("Пора выдвигаться на заказ", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            if (TimeTB.Text == "00:00:15")
            {
                timer.Stop();
                App.IsGone = true;
                Manager.MainFrame.Navigate(new AddEditPage());
                MessageBox.Show("Хватит точить мечи, пора в путь", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
