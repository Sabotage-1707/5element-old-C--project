using LAB33_KPIAP.Pages;
using LAB33_KPIAP.ViewModels;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace LAB33_KPIAP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        string login;
        string Id;
        string connectionString;

        public MainWindow(string Login, string id)
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            login = Login;
            CurrentAccount.Text = login;
            Logout.Text = "Logout";
            Id = id;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        }
        public DataTable Select(string selectSQL)
        {
            DataTable dataTable = new DataTable();
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(selectSQL, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception exec)
            {
                System.Windows.MessageBox.Show(exec.Message);
            }
            return dataTable;

        }
        private void GoToLogin(object sender, RoutedEventArgs e)
        {
            LogIn log = new LogIn();
            log.Show();
            this.Close();
        }
        private void CurrentAccountClick(object sender, RoutedEventArgs e)
        {
            ForUpadateAccount up = new ForUpadateAccount(Id);
            frame.Navigate(up);

        }

        private void GoToPhones(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Сlassification/PhonesAndPads.xaml", UriKind.Relative));
        }
        private void GoToTechniqueForKitchen(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Сlassification/TechniqueForKitchen.xaml", UriKind.Relative));
        }
        private void GoToTv(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Сlassification/VideoAndTV.xaml", UriKind.Relative));
        }
        private void GoToComputers(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Сlassification/Computers.xaml", UriKind.Relative));
        }
        private void GoToTechniqueForHome(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Сlassification/TechniqueForHome.xaml", UriKind.Relative));
        }
        private void GoToGameZone(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Сlassification/GameZone.xaml", UriKind.Relative));
        }
        private void GoToSport(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Сlassification/Sport.xaml", UriKind.Relative));
        }
        private void GoToAudio(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Сlassification/Audio.xaml", UriKind.Relative));
        }
        private void GoToRemont(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Uri(@"/Pages/Сlassification/Remont.xaml", UriKind.Relative));
        }
        private void GoTophoto(object sender, RoutedEventArgs e)
        {

            frame.NavigationService.Navigate(new Uri(@"/Pages/Сlassification/PhotoApparats.xaml", UriKind.Relative));
        }

        private void Window_Load(object sender, EventArgs e)
        {
            SearchBox.Text = "Поиск...";//подсказка
            SearchBox.Foreground = Brushes.Gray;

        }
        private void GoToKorzina(object sender, RoutedEventArgs e)
        {
            Korzina kor = new Korzina(login, Id);
            frame.Navigate(kor);
        }

        private void SearchBox_Leave(object sender, MouseEventArgs e)//происходит когда элемент стает активным
        {
            if (SearchBox.Text == "")
            {
                SearchBox.Text = "Поиск...";//подсказка
                SearchBox.Foreground = Brushes.Gray;
            }

        }

        private void SearchBox_Enter(object sender, MouseEventArgs e)
        {

            if (SearchBox.Text == "Поиск...")
            {
                SearchBox.Text = "";
                SearchBox.Foreground = Brushes.Black;
            }


        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Uri uri = new Uri("/Pages/Slaider2.xaml", UriKind.Relative);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                frame.NavigationService.Navigate(uri);
            }
        }

       

        private void Image_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Uri uri = new Uri("/Pages/Spravka.xaml", UriKind.Relative);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                frame.NavigationService.Navigate(uri);
            }
        }
        private void Image_MouseDown_2(object sender, MouseButtonEventArgs e)
        {
            Uri uri = new Uri("/Pages/Adresa.xaml", UriKind.Relative);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                frame.NavigationService.Navigate(uri);
            }
        }

        private void Search_Box_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox txtBox = e.Source as TextBox;
                if (txtBox != null)
                {
                    FoundElements f = new FoundElements(SearchBox.Text);
                    frame.Navigate(f);
                }
            }
        }
    }
}
