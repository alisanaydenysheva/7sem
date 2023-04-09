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
    /// Логика взаимодействия для Tours.xaml
    /// </summary>
    public partial class Tours : Page
    {
        public Tours()
        {
            InitializeComponent();
            var allFIOS = BlagodatEntities2.GetContext().Clients.ToList();
            allFIOS.Insert(0, new Models.Clients
            {
                fio = "Все Фамилии Имена и Отчества"
            });
            ComboFIO.ItemsSource = allFIOS;
            
               // Name = "Все Фамилии Имена и Отчества";
            
            var currentTours = BlagodatEntities2.GetContext().Clients.ToList();
            LViewTours.ItemsSource = currentTours;
            UpdateClients();
        }
        private void UpdateClients()
        {
            var currentClients = Models.BlagodatEntities2.GetContext().Clients.ToList();

           

            currentClients = currentClients.Where(p => p.fio.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();

            if (CheckBolshe.IsChecked.Value)
            {
               
                LViewTours.ItemsSource = currentClients.OrderBy(p => p.fio).ToList();

            }
           
            
           

            


        }
        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = TBoxSearch.Text;

            // Создаем CollectionView из источника данных в LViewTours
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(LViewTours.ItemsSource);

            // Устанавливаем фильтр для отображения только тех клиентов, чье имя содержит введенный текст
            view.Filter = (item) =>
            {
                if (item is Clients client)
                {
                    return client.fio.Contains(searchText);
                }
                return false;
            };
        }



        private void ComboFIO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateClients();
        }

        private void CheckBolshe_Checked(object sender, RoutedEventArgs e)
        {
            var codes = BlagodatEntities2.GetContext().Clients.Where(x => x.PassCode > 5000).ToList();
            LViewTours.ItemsSource = codes.OrderBy(x => x.PassCode).ToList();
        }

        private void CheckBolshe_Unchecked(object sender, RoutedEventArgs e)
        {
            var currentTours = BlagodatEntities2.GetContext().Clients.ToList();
            LViewTours.ItemsSource = currentTours;
        }
    }
}
