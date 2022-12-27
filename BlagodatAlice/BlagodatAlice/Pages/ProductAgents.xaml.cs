
using BlagodatAlice.Pages;
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
using BlagodatAlice.Models;

namespace BlagodatAlice
{
    /// <summary>
    /// Логика взаимодействия для ProductAgents.xaml
    /// </summary>
    public partial class ProductAgents : Page
    {
        public ProductAgents()
        {
            InitializeComponent();
          /* DGridProducts.ItemsSource = BlagodatAlibekov195Entities.GetContext().productsale.ToList();*/
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditPage());
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                BlagodatAliceEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridProducts.ItemsSource = BlagodatAliceEntities.GetContext().productsale.ToList();
            }
        }
    }
}
