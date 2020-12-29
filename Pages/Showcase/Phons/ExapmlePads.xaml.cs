using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace LAB33_KPIAP.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExapmlePads.xaml
    /// </summary>
    public partial class ExapmlePads : Page
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
                    select = "Select id_Товара, name, price, Image, x.System_Type, x.Memory, x.HardMemory, x.Diagonal, Matrix From Товар JOIN(SELECT ТИП_Товара.id, System_Type, Memory, HardMemory, Diagonal, Matrix FROM ТИП_Товара JOIN Планшеты ON(ТИП_Товара.id = Планшеты.id)) x ON(x.id = Товар.id_Type) ORDER BY price";
                    break;
                case 2:
                    select = "Select id_Товара, name, price, Image, x.System_Type, x.Memory, x.HardMemory, x.Diagonal, Matrix From Товар JOIN(SELECT ТИП_Товара.id, System_Type, Memory, HardMemory, Diagonal, Matrix FROM ТИП_Товара JOIN Планшеты ON(ТИП_Товара.id = Планшеты.id)) x ON(x.id = Товар.id_Type) ORDER BY price DESC";
                    break;
                case 3:
                    select = "Select id_Товара, name, price, Image, x.System_Type, x.Memory, x.HardMemory, x.Diagonal, Matrix From Товар JOIN(SELECT ТИП_Товара.id, System_Type, Memory, HardMemory, Diagonal, Matrix FROM ТИП_Товара JOIN Планшеты ON(ТИП_Товара.id = Планшеты.id)) x ON(x.id = Товар.id_Type) ORDER BY Name";

                    break;
            }
            
            Initialization(select, NameExamplePad1Y, CodeExamplePad1Y, PriceExamplePad1, LinExamplePad1Y, MemoryExamplePad1Y, HardMemoryExamplePad1Y, DiagonalExamplePad1Y, MatrixExamplePad1Y, ExamplePad1, 0);
            Initialization(select, NameExamplePad2Y, CodeExamplePad2Y, PriceExamplePad2, LinExamplePad2Y, MemoryExamplePad2Y, HardMemoryExamplePad2Y, DiagonalExamplePad2Y, MatrixExamplePad2Y, ExamplePad2, 1);
            Initialization(select, NameExamplePad3Y, CodeExamplePad3Y, PriceExamplePad3, LinExamplePad3Y, MemoryExamplePad3Y, HardMemoryExamplePad3Y, DiagonalExamplePad3Y, MatrixExamplePad3Y, ExamplePad3, 2);
        }
            public ExapmlePads()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            select = "Select id_Товара, name, price, Image, x.System_Type, x.Memory, x.HardMemory, x.Diagonal, Matrix From Товар JOIN(SELECT ТИП_Товара.id, System_Type, Memory, HardMemory, Diagonal, Matrix FROM ТИП_Товара JOIN Планшеты ON(ТИП_Товара.id = Планшеты.id)) x ON(x.id = Товар.id_Type)";
            Initialization(select, NameExamplePad1Y, CodeExamplePad1Y, PriceExamplePad1, LinExamplePad1Y, MemoryExamplePad1Y, HardMemoryExamplePad1Y, DiagonalExamplePad1Y, MatrixExamplePad1Y, ExamplePad1, 0);
            Initialization(select, NameExamplePad2Y, CodeExamplePad2Y, PriceExamplePad2, LinExamplePad2Y, MemoryExamplePad2Y, HardMemoryExamplePad2Y, DiagonalExamplePad2Y, MatrixExamplePad2Y, ExamplePad2, 1);
            Initialization(select, NameExamplePad3Y, CodeExamplePad3Y, PriceExamplePad3, LinExamplePad3Y, MemoryExamplePad3Y, HardMemoryExamplePad3Y, DiagonalExamplePad3Y, MatrixExamplePad3Y, ExamplePad3, 2);

        }

        private void Initialization(string select, TextBlock Name, TextBlock Code, TextBlock Price, TextBlock Lin, TextBlock Memory, TextBlock HardMemory, TextBlock Diagonal, TextBlock Matrix, Image image, int i)
        {
            DataTable Goods = Select(select);
            Name.Text = Convert.ToString(Goods.Rows[i][1]);
            Code.Text = Convert.ToString(Goods.Rows[i][0]);
            Price.Text = " " + Convert.ToString(Goods.Rows[i][2]);
            Lin.Text = Convert.ToString(Goods.Rows[i][4]);
            Memory.Text = Convert.ToString(Goods.Rows[i][5]);
            HardMemory.Text = Convert.ToString(Goods.Rows[i][6]);
            Diagonal.Text = Convert.ToString(Goods.Rows[i][7]);
            Matrix.Text = Convert.ToString(Goods.Rows[i][8]);

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

        private void BuyExamplePad1(object sender, RoutedEventArgs e)
        {
            buy(NameExamplePad1Y, PriceExamplePad1, ExamplePad1);
        }
        private void BuyExamplePad2(object sender, RoutedEventArgs e)
        {
            buy(NameExamplePad2Y, PriceExamplePad2, ExamplePad2);
        }
        private void BuyExamplePad3(object sender, RoutedEventArgs e)
        {
            buy(NameExamplePad3Y, PriceExamplePad3, ExamplePad3);
        }
    }
}
