using System;
using System.Windows;
using WPF___Турагентство.Frames;

namespace WPF___Турагентство
{
    public partial class MainTravelAgency : Window
    {
        public MainTravelAgency()
        {
            InitializeComponent();
            framePages.Navigate(new HotelFrame());
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

        private void buttonHotel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonEditing_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
