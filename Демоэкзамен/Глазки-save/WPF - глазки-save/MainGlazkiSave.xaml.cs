using System;
using System.Windows;
using WPF___глазки_save.frame;

namespace WPF___глазки_save
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainGlazkiSave : Window
    {
        public MainGlazkiSave()
        {
            InitializeComponent();
            framePages.Navigate(new User());
        }

        private void buttonAdmin_Click(object sender, RoutedEventArgs e)
        {
            framePages.Navigate(new Admin());
        }
        private void buttonUser_Click(object sender, RoutedEventArgs e)
        {
            framePages.Navigate(new User());
        }
        private void buttonBack_Click(object sender, RoutedEventArgs e)
        {
            framePages.GoBack();
        }

        private void framePages_Back(object sender, EventArgs e)
        {
            if (framePages.CanGoBack) { buttonBack.Visibility = Visibility.Visible; }
            else { buttonBack.Visibility = Visibility.Hidden; }
        }
    }
}
