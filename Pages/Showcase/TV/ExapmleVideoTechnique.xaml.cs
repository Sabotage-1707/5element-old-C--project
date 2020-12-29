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
    /// Логика взаимодействия для ExapmleVideoTechnique.xaml
    /// </summary>
    public partial class ExapmleVideoTechnique : Page
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
                    select = "Select id_Товара, name, price, Image, x.Power, x.USB, x.Bluetooth From Товар JOIN (SELECT ТИП_Товара.id, Power, USB, Bluetooth FROM ТИП_Товара JOIN Видеотехника ON(ТИП_Товара.id = Видеотехника.id)) x ON(x.id = Товар.id_Type) ORDER BY price";
                    break;
                case 2:
                    select = "Select id_Товара, name, price, Image, x.Power, x.USB, x.Bluetooth From Товар JOIN (SELECT ТИП_Товара.id, Power, USB, Bluetooth FROM ТИП_Товара JOIN Видеотехника ON(ТИП_Товара.id = Видеотехника.id)) x ON(x.id = Товар.id_Type) ORDER BY price DESC";
                    break;
                case 3:
                    select = "Select id_Товара, name, price, Image, x.Power, x.USB, x.Bluetooth From Товар JOIN (SELECT ТИП_Товара.id, Power, USB, Bluetooth FROM ТИП_Товара JOIN Видеотехника ON(ТИП_Товара.id = Видеотехника.id)) x ON(x.id = Товар.id_Type) ORDER BY Name";
                    break;
            }
            Initialization(select, NameExamplePanel1Y, CodeExamplePanel1Y, PriceExamplePanel1, PowerExamplePanel1Y, USBExamplePanel1Y, BluetoothExamplePanel1Y, ExamplePanel1, 0);
            Initialization(select, NameExamplePanel2Y, CodeExamplePanel2Y, PriceExamplePanel2, PowerExamplePanel2Y, USBExamplePanel2Y, BluetoothExamplePanel2Y, ExamplePanel2, 1);
            Initialization(select, NameExamplePanel3Y, CodeExamplePanel3Y, PriceExamplePanel3, PowerExamplePanel3Y, USBExamplePanel3Y, BluetoothExamplePanel3Y, ExamplePanel3, 2);
        }
        public ExapmleVideoTechnique()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            select = "Select id_Товара, name, price, Image, x.Power, x.USB, x.Bluetooth From Товар JOIN (SELECT ТИП_Товара.id, Power, USB, Bluetooth FROM ТИП_Товара JOIN Видеотехника ON(ТИП_Товара.id = Видеотехника.id)) x ON(x.id = Товар.id_Type)";

            Initialization(select, NameExamplePanel1Y, CodeExamplePanel1Y, PriceExamplePanel1, PowerExamplePanel1Y, USBExamplePanel1Y, BluetoothExamplePanel1Y, ExamplePanel1, 0);
            Initialization(select, NameExamplePanel2Y, CodeExamplePanel2Y, PriceExamplePanel2, PowerExamplePanel2Y, USBExamplePanel2Y, BluetoothExamplePanel2Y, ExamplePanel2, 1);
            Initialization(select, NameExamplePanel3Y, CodeExamplePanel3Y, PriceExamplePanel3, PowerExamplePanel3Y, USBExamplePanel3Y, BluetoothExamplePanel3Y, ExamplePanel3, 2);

        }

        private void Initialization(string select, TextBlock Name, TextBlock Code, TextBlock Price, TextBlock Power, TextBlock USB, TextBlock Bluetooth, Image image, int i)
        {
            DataTable Goods = Select(select);
            Name.Text = Convert.ToString(Goods.Rows[i][1]);
            Code.Text = Convert.ToString(Goods.Rows[i][0]);
            Price.Text = " " + Convert.ToString(Goods.Rows[i][2]);
            Power.Text = Convert.ToString(Goods.Rows[i][4]);
            USB.Text = Convert.ToString(Goods.Rows[i][5]);
            Bluetooth.Text = Convert.ToString(Goods.Rows[i][6]);

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

        private void BuyExamplePanel1(object sender, RoutedEventArgs e)
        {
            buy(NameExamplePanel1Y, PriceExamplePanel1, ExamplePanel1);
        }
        private void BuyExamplePanel2(object sender, RoutedEventArgs e)
        {
            buy(NameExamplePanel2Y, PriceExamplePanel2, ExamplePanel2);
        }
        private void BuyExamplePanel3(object sender, RoutedEventArgs e)
        {
            buy(NameExamplePanel3Y, PriceExamplePanel3, ExamplePanel3);
        }
    }
}
