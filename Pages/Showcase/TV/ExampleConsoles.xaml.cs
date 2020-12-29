using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace LAB33_KPIAP.Pages.Showcase
{
    /// <summary>
    /// Логика взаимодействия для ExampleConsoles.xaml
    /// </summary>
    public partial class ExampleConsoles : Page
    {
        string connectionString;
        string select = "";
        public void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton rb = sender as System.Windows.Controls.RadioButton;
            if (rb != null)
            {
                string profession = rb.Tag.ToString();
                switch (profession)
                {
                    case "Price":
                        Load(1);
                        break;

                    case "Price2":
                        Load(2);
                        break;
                    case "Name":
                        Load(3);
                        break;
                }
            }
        }
        public void Load(int numb)
        {
            
            switch (numb)
            {
                case 1:
                    select = "Select id_Товара, name, price, Image, Type, Nositeli, Wifi From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Приставки ON(ТИП_Товара.id = Приставки.id) ORDER BY price";
                    break;
                case 2:
                    select = "Select id_Товара, name, price, Image, Type, Nositeli, Wifi From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Приставки ON(ТИП_Товара.id = Приставки.id) ORDER BY price DESC";
                    break;
                case 3:
                    select = "Select id_Товара, name, price, Image, Type, Nositeli, Wifi From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Приставки ON(ТИП_Товара.id = Приставки.id) ORDER BY Name";
                    break;
            }

            Initialization(select, NameExampleConsole1Y, CodeExampleConsole1Y, PriceExampleConsole1, LinExampleConsole1Y, NositeliExampleConsole1Y, WifiExampleConsole1Y, ExampleConsole1, 0);
            Initialization(select, NameExampleConsole2Y, CodeExampleConsole2Y, PriceExampleConsole2, LinExampleConsole2Y, NositeliExampleConsole2Y, WifiExampleConsole2Y, ExampleConsole2, 1);
            Initialization(select, NameExampleConsole3Y, CodeExampleConsole3Y, PriceExampleConsole3, LinExampleConsole3Y, NositeliExampleConsole3Y, WifiExampleConsole3Y, ExampleConsole3, 2);
        }
        public ExampleConsoles()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            select = "Select id_Товара, name, price, Image, Type, Nositeli, Wifi From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Приставки ON(ТИП_Товара.id = Приставки.id)"; 
            Initialization(select, NameExampleConsole1Y, CodeExampleConsole1Y, PriceExampleConsole1, LinExampleConsole1Y, NositeliExampleConsole1Y, WifiExampleConsole1Y, ExampleConsole1, 0);
            Initialization(select, NameExampleConsole2Y, CodeExampleConsole2Y, PriceExampleConsole2, LinExampleConsole2Y, NositeliExampleConsole2Y, WifiExampleConsole2Y, ExampleConsole2, 1);
            Initialization(select, NameExampleConsole3Y, CodeExampleConsole3Y, PriceExampleConsole3, LinExampleConsole3Y, NositeliExampleConsole3Y, WifiExampleConsole3Y, ExampleConsole3, 2);

        }

        private void Initialization(string select, TextBlock Name, TextBlock Code, TextBlock Price, TextBlock Lin, TextBlock Nositeli, TextBlock Wifi, Image image, int i)
        {
            DataTable Goods = Select(select);
            Name.Text = Convert.ToString(Goods.Rows[i][1]);
            Code.Text = Convert.ToString(Goods.Rows[i][0]);
            Price.Text = " " + Convert.ToString(Goods.Rows[i][2]);
            Lin.Text = Convert.ToString(Goods.Rows[i][4]);
            Nositeli.Text = Convert.ToString(Goods.Rows[i][5]);
            Wifi.Text = Convert.ToString(Goods.Rows[i][6]);

            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            string path1 = Convert.ToString(Goods.Rows[i][3]);
            myBitmapImage.UriSource = new Uri($@"{path1}");
            myBitmapImage.EndInit();
            image.Source = myBitmapImage;
        }
        private void buy(TextBlock Name, TextBlock Price, Image image)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(connectionString);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format("INSERT INTO  Korzina( Image, Name , Price ) VALUES (N'{0}', N'{1}' , N'{2}')", image.Source, Name.Text, Price.Text);
            cmd.Connection = connection;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show($"Добавлено в корзину");

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
                MessageBox.Show(exec.Message);
            }
            return dataTable;

        }

        private void BuyExampleConsole1(object sender, RoutedEventArgs e)
        {
            buy(NameExampleConsole1Y, PriceExampleConsole1, ExampleConsole1);
        }
        private void BuyExampleConsole2(object sender, RoutedEventArgs e)
        {
            buy(NameExampleConsole2Y, PriceExampleConsole2, ExampleConsole2);
        }
        private void BuyExampleConsole3(object sender, RoutedEventArgs e)
        {
            buy(NameExampleConsole3Y, PriceExampleConsole3, ExampleConsole3);
        }
    }
}
