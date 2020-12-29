using System;
using System.Windows;
using System.Windows.Controls;

namespace LAB33_KPIAP.Pages
{
    /// <summary>
    /// Логика взаимодействия для PhonesAndPads.xaml
    /// </summary>
    public partial class PhonesAndPads : Page
    {
        public PhonesAndPads()
        {
            InitializeComponent();

        }
       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame2.NavigationService.Navigate(new Uri(@"/Pages/Showcase/Phons/ExamplePhones.xaml", UriKind.Relative));
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            Frame2.NavigationService.Navigate(new Uri(@"/Pages/Showcase/Phons/ExapmlePads.xaml", UriKind.Relative));
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            Frame2.NavigationService.Navigate(new Uri(@"/Pages/Showcase/Phons/ExampleAcsForGadgets.xaml", UriKind.Relative));
        }
    }
}
