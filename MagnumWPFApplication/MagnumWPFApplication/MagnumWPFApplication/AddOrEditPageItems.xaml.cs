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
    /// Логика взаимодействия для AddOrEditPageItems.xaml
    /// </summary>
    public partial class AddOrEditPageItems : Page
    {
        private bool _isNew = false;
        private Items _currentitem= null;
        public AddOrEditPageItems(Items currentitem)
        {
            InitializeComponent();
            if(currentitem != null)
            {
                _currentitem = currentitem;
                DataContext= _currentitem;
            }
            else
            {
                _isNew = true;
                _currentitem = new Items();
                DataContext= _currentitem;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(_currentitem.ItemID == 0 && !_isNew) 
            {
                MessageBox.Show("Select row to change");
                return;
            }
            try
            {
                ActioRusBDEntities context = ActioRusBDEntities.GetContext();
                if (_isNew)
                {
                    context.Items.Add(_currentitem);
                }
                context.SaveChanges();
                MessageBox.Show("Saved!!!");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
