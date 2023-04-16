using ActioRusApp.Classes;
using ActioRusApp.Models;
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

namespace ActioRusApp
{
    /// <summary>
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        int _currentPage = 1, _countInPage = 10, _maxPages;
        public AdminPage()
        {
            InitializeComponent();
            ItemsView.ItemsSource = ActioRusBDEntities.GetContext().Items.ToList();
        }

        private void Button_RedClick(object sender, RoutedEventArgs e)
        {

        }

        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            RefreshData();
        }

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage--;
            RefreshData();
        }

        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage++;
            RefreshData();
        }

        private void BtnLastPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = _maxPages;
            RefreshData();
        }

        private void BtnRedData_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddOrEditPageItems((sender as Button).DataContext as Items));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDel_Click(object sender, RoutedEventArgs e)
        {
            var ItemForRemoving = ItemsView.SelectedItems.Cast<Items>().ToList();

            if (MessageBox.Show($"Вы собираетесь удалить {ItemForRemoving.Count()} записей", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    ActioRusBDEntities.GetContext().Items.RemoveRange(ItemForRemoving);
                    ActioRusBDEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");

                    RefreshData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void RefreshData()
        {
            var data = ActioRusBDEntities.GetContext().Items.ToList();
            ItemsView.ItemsSource= data;
        }
    }
}
