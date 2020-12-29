using System;
using System.Windows;
using System.Windows.Controls;

namespace LAB33_KPIAP.Pages
{
    /// <summary>
    /// Логика взаимодействия для TechniqueForKitchen.xaml
    /// </summary>
    public partial class TechniqueForKitchen : Page
    {
        public TechniqueForKitchen()
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
