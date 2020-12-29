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
    /// Логика взаимодействия для ExampleNoutBooks.xaml
    /// </summary>
    public partial class ExampleNoutBooks : Page
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
                    select = "Select id_Товара, name, price, Image, Seria, TypeSystem,  VideoKart_Type, HardMemory, Seria_Proc, HardDrive From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Ноутбуки ON(ТИП_Товара.id = Ноутбуки.id) ORDER BY price ";
                    break;
                case 2:
                    select = "Select id_Товара, name, price, Image, Seria, TypeSystem,  VideoKart_Type, HardMemory, Seria_Proc, HardDrive From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Ноутбуки ON(ТИП_Товара.id = Ноутбуки.id) ORDER BY price DESC";
                    break;
                case 3:
                    select = "Select id_Товара, name, price, Image, Seria, TypeSystem,  VideoKart_Type, HardMemory, Seria_Proc, HardDrive From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Ноутбуки ON(ТИП_Товара.id = Ноутбуки.id) ORDER BY Name";

                    break;
            }

            Initialization(select, NameExampleNoutBook1Y, CodeExampleNoutBook1Y, PriceExampleNoutBook1, SeriaExampleNoutBook1Y, TypeExampleNoutBook1Y, VideoKartExampleNoutBook1Y, SeriaProcExampleNoutBook1Y, HardMemoryExampleNoutBook1Y, HardDriveExampleNoutBook1Y, ExampleNoutBook1, 0);
            Initialization(select, NameExampleNoutBook2Y, CodeExampleNoutBook2Y, PriceExampleNoutBook2, SeriaExampleNoutBook2Y, TypeExampleNoutBook2Y, VideoKartExampleNoutBook2Y, SeriaProcExampleNoutBook2Y, HardMemoryExampleNoutBook2Y, HardDriveExampleNoutBook2Y, ExampleNoutBook2, 1);
            Initialization(select, NameExampleNoutBook3Y, CodeExampleNoutBook3Y, PriceExampleNoutBook3, SeriaExampleNoutBook3Y, TypeExampleNoutBook3Y, VideoKartExampleNoutBook3Y, SeriaProcExampleNoutBook3Y, HardMemoryExampleNoutBook3Y, HardDriveExampleNoutBook3Y, ExampleNoutBook3, 2);
        }
        public ExampleNoutBooks()
        {
            InitializeComponent();

            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            select = "Select id_Товара, name, price, Image, Seria, TypeSystem,  VideoKart_Type, HardMemory, Seria_Proc, HardDrive From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Ноутбуки ON(ТИП_Товара.id = Ноутбуки.id)";
            Initialization(select,NameExampleNoutBook1Y, CodeExampleNoutBook1Y, PriceExampleNoutBook1, SeriaExampleNoutBook1Y, TypeExampleNoutBook1Y, VideoKartExampleNoutBook1Y, SeriaProcExampleNoutBook1Y, HardMemoryExampleNoutBook1Y, HardDriveExampleNoutBook1Y, ExampleNoutBook1, 0);
            Initialization(select,NameExampleNoutBook2Y, CodeExampleNoutBook2Y, PriceExampleNoutBook2, SeriaExampleNoutBook2Y, TypeExampleNoutBook2Y, VideoKartExampleNoutBook2Y, SeriaProcExampleNoutBook2Y, HardMemoryExampleNoutBook2Y, HardDriveExampleNoutBook2Y, ExampleNoutBook2, 1);
            Initialization(select,NameExampleNoutBook3Y, CodeExampleNoutBook3Y, PriceExampleNoutBook3, SeriaExampleNoutBook3Y, TypeExampleNoutBook3Y, VideoKartExampleNoutBook3Y, SeriaProcExampleNoutBook3Y, HardMemoryExampleNoutBook3Y, HardDriveExampleNoutBook3Y, ExampleNoutBook3, 2);

        }

        private void Initialization(string select,TextBlock Name, TextBlock Code, TextBlock Price, TextBlock Seria, TextBlock Type, TextBlock VideoKart, TextBlock SeriaProc, TextBlock HardMemory, TextBlock HardDrive, Image image, int i)
        {
            DataTable Goods = Select(select);
            Name.Text = Convert.ToString(Goods.Rows[i][1]);
            Code.Text = Convert.ToString(Goods.Rows[i][0]);
            Price.Text = " " + Convert.ToString(Goods.Rows[i][2]);
            Seria.Text = Convert.ToString(Goods.Rows[i][4]);
            Type.Text = Convert.ToString(Goods.Rows[i][5]);
            VideoKart.Text = Convert.ToString(Goods.Rows[i][6]);
            SeriaProc.Text = Convert.ToString(Goods.Rows[i][7]);
            HardMemory.Text = Convert.ToString(Goods.Rows[i][8]);
            HardDrive.Text = Convert.ToString(Goods.Rows[i][9]);

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
            cmd.CommandText = string.Format("INSERT INTO  Korzina( Image, Name , Price ) VALUES (N'{0} ', N'{1}' , N'{2}')", image.Source, Name.Text, Price.Text);
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

        private void BuyExampleNoutBook1(object sender, RoutedEventArgs e)
        {
            buy(NameExampleNoutBook1Y, PriceExampleNoutBook1, ExampleNoutBook1);
        }
        private void BuyExampleNoutBook2(object sender, RoutedEventArgs e)
        {
            buy(NameExampleNoutBook2Y, PriceExampleNoutBook2, ExampleNoutBook2);
        }
        private void BuyExampleNoutBook3(object sender, RoutedEventArgs e)
        {
            buy(NameExampleNoutBook3Y, PriceExampleNoutBook3, ExampleNoutBook3);
        }
    }
}
