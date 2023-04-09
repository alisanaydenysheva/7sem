using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
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
    /// Interaction logic for RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        
       
        public RegPage()
        {
            InitializeComponent();

           
        }

        private void Login(object sender, RoutedEventArgs e)
        {
          
        }

        private void LoginUs_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TbxShowPass_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Collapsed;
            TxbPassword.Text = Password.Password;
            
        }

        private void TbxShowPass_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TxbPassword.Visibility = Visibility.Collapsed;
            Password.Visibility = Visibility.Visible;
        }
    }
}
