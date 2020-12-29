using System;
using System.Windows;
using System.Windows.Controls;

namespace LAB33_KPIAP.Pages.Сlassification
{
    /// <summary>
    /// Логика взаимодействия для PhotoApparats.xaml
    /// </summary>
    public partial class PhotoApparats : Page
    {
        public PhotoApparats()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Showcase/Phons/ExamplePhones.xaml", UriKind.Relative));
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Showcase/Phons/ExapmlePads.xaml", UriKind.Relative));
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Showcase/Phons/ExapmlePads.xaml", UriKind.Relative));
        }
    }
}
