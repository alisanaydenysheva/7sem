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
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    public partial class HotelsPage : Page
    {
        /// <summary>
        /// Работа со страницей отелей
        /// </summary>
        public HotelsPage()
        {
            InitializeComponent();
            DGridHotels.ItemsSource = GachiToursEntities.GetContext().Hotels.ToList();
        }

        /// <summary>
        /// Обработка нажатия кнопки "Редактировать"
        /// </summary>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage2((sender as Button).DataContext as Hotel));
        }
        /// <summary>
        /// Обработка нажатия кнопки "Добавить"
        /// </summary>
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage2(null));
        }

        /// <summary>
        /// Обработка нажатия кнопки удаления
        /// </summary>
        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var hotelsForRemoving = DGridHotels.SelectedItems.Cast<Hotel>().ToList();

            if (MessageBox.Show($"Are you sure to delete data {hotelsForRemoving.Count()}", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    GachiToursEntities.GetContext().Hotels.RemoveRange(hotelsForRemoving);
                    GachiToursEntities.GetContext().SaveChanges();
                    MessageBox.Show("Data deleted");

                    DGridHotels.ItemsSource = GachiToursEntities.GetContext().Hotels.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
        /// <summary>
        /// Функция отвечает за отображение новых данных после редактирования
        /// </summary>
        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                GachiToursEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotels.ItemsSource = GachiToursEntities.GetContext().Hotels.ToList();
            }
        }

        private void DGridHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
