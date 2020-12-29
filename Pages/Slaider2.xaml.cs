using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LAB33_KPIAP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Slaider.xaml
    /// </summary>
    public partial class Slaider2 : Page
    {
        public Slaider2()
        {
            InitializeComponent();
            ChangeBackground(btn1, Brushes.Coral, new Thickness(4.0));
        }
        public void btn1_Click(object sender, RoutedEventArgs e)
        {
            ChangeBackground(btn1, Brushes.Coral, new Thickness(4.0));
            ChangeBackground(btn2, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn3, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn4, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn5, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn6, Brushes.LightGray, new Thickness(0.0));
            ImageSource src = new BitmapImage(new Uri(Environment.CurrentDirectory + "/01.png", UriKind.Absolute));
            image.Source = src;

        }
        public void btn2_Click(object sender, RoutedEventArgs e)
        {
            ChangeBackground(btn2, Brushes.Coral, new Thickness(4.0));

            ChangeBackground(btn1, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn3, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn4, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn5, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn6, Brushes.LightGray, new Thickness(0.0));
            ImageSource src = new BitmapImage(new Uri(Environment.CurrentDirectory + "/02.png", UriKind.Absolute));
            image.Source = src;

        }
        public void btn3_Click(object sender, RoutedEventArgs e)
        {
            ChangeBackground(btn3, Brushes.Coral, new Thickness(4.0));
            ChangeBackground(btn1, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn2, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn4, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn5, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn6, Brushes.LightGray, new Thickness(0.0));
            ImageSource src = new BitmapImage(new Uri(Environment.CurrentDirectory + "/03.png", UriKind.Absolute));
            image.Source = src;

        }
        public void btn4_Click(object sender, RoutedEventArgs e)
        {
            ChangeBackground(btn4, Brushes.Coral, new Thickness(4.0));

            ChangeBackground(btn1, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn3, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn2, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn5, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn6, Brushes.LightGray, new Thickness(0.0));
            ImageSource src = new BitmapImage(new Uri(Environment.CurrentDirectory + "/04.png", UriKind.Absolute));
            image.Source = src;
        }
        public void btn5_Click(object sender, RoutedEventArgs e)
        {
            ChangeBackground(btn5, Brushes.Coral, new Thickness(4.0));
            ChangeBackground(btn1, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn3, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn4, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn2, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn6, Brushes.LightGray, new Thickness(0.0));
            ImageSource src = new BitmapImage(new Uri(Environment.CurrentDirectory + "/05.png", UriKind.Absolute));
            image.Source = src;

        }
        public void btn6_Click(object sender, RoutedEventArgs e)
        {
            ChangeBackground(btn6, Brushes.Coral, new Thickness(4.0));

            ChangeBackground(btn1, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn3, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn4, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn5, Brushes.LightGray, new Thickness(0.0));
            ChangeBackground(btn2, Brushes.LightGray, new Thickness(0.0));
            ImageSource src = new BitmapImage(new Uri(Environment.CurrentDirectory + "/06.png", UriKind.Absolute));
            image.Source = src;
        }
        private void ChangeBackground(Button btn, Brush brush, Thickness thickness)
        {
            btn.Background = brush;
            btn.BorderBrush = Brushes.White;
            btn.BorderThickness = thickness;

        }
    }
}
