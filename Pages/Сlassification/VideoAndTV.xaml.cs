using System;
using System.Windows;
using System.Windows.Controls;

namespace LAB33_KPIAP.Pages
{
    /// <summary>
    /// Логика взаимодействия для VideoAndTV.xaml
    /// </summary>
    public partial class VideoAndTV : Page
    {
        public VideoAndTV()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Showcase/TV/ExampleTV.xaml", UriKind.Relative));
        }
        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Showcase/TV/ExampleConsoles.xaml", UriKind.Relative));
        }
        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Showcase/TV/ExapmleVideoTechnique.xaml", UriKind.Relative));
        }
    }
}
