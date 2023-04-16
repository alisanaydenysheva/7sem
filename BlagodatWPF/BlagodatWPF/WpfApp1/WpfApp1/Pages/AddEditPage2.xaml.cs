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
        private Hotel _currentHotel = new Hotel();
        public AddEditPage2(Hotel selectedHotel)
        {
            InitializeComponent();
            if (selectedHotel != null)
            {
                _currentHotel = selectedHotel;
            }
            DataContext = _currentHotel;
            ComboCounries.ItemsSource = GachiToursEntities.GetContext().Countries.ToList();
        }

        /// <summary>
        /// Функция отвечает за сохранение данных в БД после нажатия на кнопку
        /// </summary>
        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentHotel.Name))
            {
                errors.AppendLine("Enter Hotel Name");
            }
            if (_currentHotel.Stars < 1 || _currentHotel.Stars > 5)
            {
                errors.AppendLine("Stars 1-5 only");
            }
            if (_currentHotel.Name == null)
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
                GachiToursEntities.GetContext().Hotels.Add(_currentHotel);
            }

            try
            {

                GachiToursEntities.GetContext().SaveChanges();
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
