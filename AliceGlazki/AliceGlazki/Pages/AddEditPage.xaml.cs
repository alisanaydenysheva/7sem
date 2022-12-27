
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
using WordSkills.Classes;
using WordSkills.Models;

namespace Blagodat.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    { 
        private productsale _currentProduct = new productsale();
        public AddEditPage()
        {
            InitializeComponent();
            DataContext = _currentProduct;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            DateTime newDate = DateTime.Now;
            _currentProduct.date_realize = newDate;
            StringBuilder errors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(_currentProduct.prod))
                errors.AppendLine("Укажите название продукта");
            if (_currentProduct.num_of_prod < 1)
                errors.AppendLine("Некорректно введен номер продукта ");

            if (errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if (_currentProduct.id == 0)
                GlazkiSaveAuth.GetContext().productsale.Add(_currentProduct);

            try
            {
                GlazkiSaveAuth.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                Manager.MainFrame.GoBack();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }


        }
    }
}
