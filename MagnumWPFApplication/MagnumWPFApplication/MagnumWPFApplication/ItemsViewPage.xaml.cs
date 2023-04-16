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
    /// Логика взаимодействия для ItemsViewPage.xaml
    /// </summary>
    public partial class ItemsViewPage : Page
    {
        private List<Items> allItems;
        public ItemsViewPage()
        {
            InitializeComponent();
            //  this.user = user;
            // Получаем все марки и привязываем к комбобоксу
            var allMarks = ActioRusBDEntities.GetContext().Items.ToList();
            JenresList.ItemsSource = allMarks;
            JenresList.DisplayMemberPath = "ItemType";
            JenresList.SelectedValue = "ItemType";


            // Получаем все автомобили и запоминаем их
            allItems = ActioRusBDEntities.GetContext().Items.ToList();
            // List<Dates> dates = VerticalBDEntities1.GetContext().Dates.ToList();
            // DatesComboBox.ItemsSource = dates;
            // DatesComboBox.DisplayMemberPath = "Date";


            // Заполняем список автомобилей по умолчанию
            UpdateCarsPage();
        }
        private void UpdateCarsPage()
        {
            // Создаем копию всех автомобилей, чтобы фильтровать только ее
            var currentCars = allItems.ToList();

            // Фильтруем список автомобилей по поисковому запросу
            string searchText = SearchList.Text.ToLower();
            currentCars = currentCars.Where(p => p.ItemName.ToLower().Contains(searchText) || p.Description.ToLower().Contains(searchText)).ToList();



            // Фильтруем список автомобилей по выбранной марке

            var selectedJenre = JenresList.SelectedItem as Items;
            if (selectedJenre != null)
            {
                var selectedJenreId = selectedJenre.ItemType;
                currentCars = currentCars.Where(p => p.ItemType == selectedJenreId).ToList();
            }

            // Обновляем список спектаклей на странице
            CarsViewPanel.ItemsSource = currentCars;
        }

        private void ActualCars_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void SearchList_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void MarksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void ActualCars_Checked(object sender, RoutedEventArgs e)
        {
            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void PodZakaz_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void PodZakaz_Checked(object sender, RoutedEventArgs e)
        {

            UpdateCarsPage();
            ClientDataPAnel.Visibility = Visibility.Collapsed;
        }

        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            // Сбрасываем значения фильтров и поискового поля
            SearchList.Text = "";
            JenresList.SelectedIndex = -1;
            // ActualCars.IsChecked = false;
            // PodZakaz.IsChecked = false;

            // Сбрасываем сортировку
            CollectionViewSource.GetDefaultView(CarsViewPanel.ItemsSource).SortDescriptions.Clear();

            // Сбрасываем фильтры
            CollectionViewSource.GetDefaultView(CarsViewPanel.ItemsSource).Filter = null;
            ClientDataPAnel.Visibility = Visibility.Collapsed;
            // Обновляем список автомобилей на странице
            UpdateCarsPage();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            Window newWindow = new MainWindow();
            Application.Current.MainWindow = newWindow;
            newWindow.Show();
            Window currentwindow = Window.GetWindow(this);
            currentwindow.Close();
            */
        }

        private void CarsViewPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = CarsViewPanel.SelectedItem as Items;
            if (selected != null)
            {
                var view = CollectionViewSource.GetDefaultView(CarsViewPanel.ItemsSource);
                view.Filter = item => item == selected;
                ClientDataPAnel.Visibility = Visibility.Visible;


            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var selected = CarsViewPanel.SelectedItem as Items;


            decimal discount = selected.Cost.Value * (decimal)1;
            decimal discountedPrice = selected.Cost.Value;

            // Выводим данные в MessageBox с учетом скидки
            string message = "Название товара: " + selected.ItemName + "\n" +
                             "Тип: " + selected.ItemType + "\n" +
                             "Количество: " + selected.Count + "\n" +
                             "Описание: " + selected.Description + "\n" +
                             "Цена: " + discount.ToString("#.##") + " руб.  ";

            MessageBoxResult result = MessageBox.Show(message, "Подтверждение данных", MessageBoxButton.YesNo, MessageBoxImage.Question);

            var newTestDrive = new CartTable
            {

                ItemID = 1,
                Cost = discountedPrice,
                Count = 1,
                ClientID = 1,

            };
            ActioRusBDEntities.GetContext().CartTable.Add(newTestDrive);
            ActioRusBDEntities.GetContext().SaveChanges();
            Cart.ItemsSource = ActioRusBDEntities.GetContext().CartTable.ToList();
            if (result == MessageBoxResult.No)
            {
                // Если данные неверны, можно снова скрыть ClientDataPAnel
                ClientDataPAnel.Visibility = Visibility.Collapsed;
            }

        }

        private bool isSortedAscending = false;

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
