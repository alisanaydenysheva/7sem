using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Word = Microsoft.Office.Interop.Word;
using WpfApp1.Models;
using WpfApp1.Classes;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для HotelsPage.xaml
    /// </summary>
    /// 
    
    public partial class ClientsPage : Page
    {
        
        /// <summary>
        /// Работа со страницей отелей
        /// </summary>
        /// 
        int _currentPage = 1, _countInPage = 10, _maxPages;
        public ClientsPage()
        {
            InitializeComponent();
            DGridHotels.ItemsSource = BlagodatEntities2.GetContext().Clients.ToList();
            
        }

        /// <summary>
        /// Обработка нажатия кнопки "Редактировать"
        /// </summary>
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddEditPage2((sender as Button).DataContext as Clients));
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
            var hotelsForRemoving = DGridHotels.SelectedItems.Cast<Clients>().ToList();

            if (MessageBox.Show($"Are you sure to delete data {hotelsForRemoving.Count()}", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    BlagodatEntities2.GetContext().Clients.RemoveRange(hotelsForRemoving);
                    BlagodatEntities2.GetContext().SaveChanges();
                    MessageBox.Show("Data deleted");

                    DGridHotels.ItemsSource = BlagodatEntities2.GetContext().Clients.ToList();
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
                BlagodatEntities2.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridHotels.ItemsSource = BlagodatEntities2.GetContext().Clients.ToList();
            }
        }

        private void DGridHotels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new CodePage());
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            PrintDialog pd = new PrintDialog();
            if (pd.ShowDialog() == true)
            {
                pd.PrintVisual(DGridHotels, "My First Print Job");
            }
        }
        private void RefreshData()
        {
            var data = BlagodatEntities2.GetContext().Clients.ToList();

            // List<Models.Ingredient> listIngredients = _context.Ingredient.ToList();            

            _maxPages = (int)Math.Ceiling(data.Count * 1.0 / _countInPage);
            data = data.Skip((_currentPage - 1) * _countInPage).Take(_countInPage).ToList();

            LblPages.Content = $"{_currentPage}/{_maxPages}";

            DGridHotels.ItemsSource = data;

            ManageButtonsEnable();
           
        }
        

        private void NavigateToSelectedPage(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            string pageStr = btn.Content.ToString();
            int page = int.Parse(pageStr);
            _currentPage = page;
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

        private void BtnPreviousPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage--;
            RefreshData();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Tours());
        }

        private void Button_ClickHistory(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new History());
        }

        private void BtnOtchet_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new OrdersPage());
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            Word._Application wApp = new Word.Application();
            Word._Document wDoc = wApp.Documents.Add();
            wApp.Visible = true;
            wDoc.Activate();
            var table = wDoc.Tables.Add(
            wDoc.Range(),
            DGridHotels.Items.Count + 1,
            DGridHotels.Columns.Count);

            // Заполняем заголовки столбцов
            for (int i = 0; i < DGridHotels.Columns.Count; i++)
            {
                var header = DGridHotels.Columns[i].Header;
                if (header != null)
                {
                    table.Cell(1, i + 1).Range.Text = header.ToString();
                }
                else
                {
                    table.Cell(1, i + 1).Range.Text = "";
                }
            }
            table.Borders.Enable = 1; // Отобразить границы таблицы
            table.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent); // Автоматически подгонять размер ячеек по содержимому
            table.Rows[1].Range.Bold = 1; // Жирный текст в первой строке (заголовок таблицы)
            table.Rows[1].Range.Font.Name = "Arial"; // Изменить шрифт в первой строке таблицы

            // Заполняем ячейки таблицы данными из DataGrid
            for (int i = 0; i < DGridHotels.Items.Count; i++)
            {
                var row = DGridHotels.Items[i];
                for (int j = 0; j < DGridHotels.Columns.Count; j++)

                {
                    var cellContent = DGridHotels.Columns[j].GetCellContent(row);
                    if (cellContent is FrameworkElement element)
                    {
                        // Получаем содержимое элемента
                        var cellValue = (element as TextBlock)?.Text ?? string.Empty;
                        table.Cell(i + 2, j + 1).Range.Text = cellValue;
                    }
                    else
                    {
                        // Получаем текстовое содержимое ячейки
                        var cellValue = DGridHotels.Columns[j].GetCellContent(row).ToString();
                        table.Cell(i + 2, j + 1).Range.Text = cellValue;
                    }
                }
            }
        }

        private void FormOrder_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new Orders());
        }

        private void BtnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            _currentPage = 1;
            RefreshData();

        }
        private void ManageButtonsEnable()
        {
            BtnLastPage.IsEnabled = BtnNextPage.IsEnabled = true;
            BtnFirstPage.IsEnabled = BtnPreviousPage.IsEnabled = true;

            if (_currentPage == 1)
            {
                BtnFirstPage.IsEnabled = BtnPreviousPage.IsEnabled = false;
            }

            if (_currentPage == _maxPages)
            {
                BtnLastPage.IsEnabled = BtnNextPage.IsEnabled = false;
            }
        }

    }
}
