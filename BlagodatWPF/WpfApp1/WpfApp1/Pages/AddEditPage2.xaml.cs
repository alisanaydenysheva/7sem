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
using WpfApp1.Models;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Interaction logic for AddEditPage2.xaml
    /// </summary>
    public partial class AddEditPage2 : Page
    {
        private Clients _currentClients = new Clients();
        public AddEditPage2(Clients selectedClient)
        {
            InitializeComponent();
            if (selectedClient != null)
            {
                _currentClients = selectedClient;
            }
            DataContext = _currentClients;
            //ComboCounries.ItemsSource = BlagodatEntities1.GetContext().Clients.ToList();
        }

        /// <summary>
        /// Функция отвечает за сохранение данных в БД после нажатия на кнопку
        /// </summary>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            /*if (string.IsNullOrWhiteSpace(_currentHotel.HotelName))
            {
                errors.AppendLine("Enter Hotel Name");
            }
            if (_currentHotel.Stars < 1 || _currentHotel.Stars > 5)
            {
                errors.AppendLine("Stars 1-5 only");
            }
            if (_currentHotel.CountryName == null)
            {
                errors.AppendLine("Choose a country");
            }

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentHotel.HotelID == 0)
            {
                BlagodatEntities.GetContext().Hotels.Add(_currentHotel);
            }
            */

            try
            {

                BlagodatEntities2.GetContext().SaveChanges();
                MessageBox.Show("Saved!!!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ComboCounries_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        
        {

        }
    }
}
