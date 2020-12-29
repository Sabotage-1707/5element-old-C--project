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
    /// Логика взаимодействия для ExamplePhones.xaml
    /// </summary>
    public partial class ExamplePhones : Page
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
                    select = "Select id_Товара, name, price, Image, Ruler, Memory, HardMemory, Diagonal, Тechnology From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Телефоны ON(ТИП_Товара.id = Телефоны.id) ORDER BY price";
                    break;
                case 2:
                    select = "Select id_Товара, name, price, Image, Ruler, Memory, HardMemory, Diagonal, Тechnology From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Телефоны ON(ТИП_Товара.id = Телефоны.id) ORDER BY price DESC";
                    break;
                case 3:
                    select = "Select id_Товара, name, price, Image, Ruler, Memory, HardMemory, Diagonal, Тechnology From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Телефоны ON(ТИП_Товара.id = Телефоны.id) ORDER BY Name";
                    break;
            }
            Initialization(select, NameExamplePhone1Y, CodeExamplePhone1Y, PriceExamplePhone1, LinExamplePhone1Y, MemoryExamplePhone1Y, HardMemoryExamplePhone1Y, DiagonalExamplePhone1Y, TechnologyExamplePhone1Y, ExamplePhone1, 0);
            Initialization(select, NameExamplePhone2Y, CodeExamplePhone2Y, PriceExamplePhone2, LinExamplePhone2Y, MemoryExamplePhone2Y, HardMemoryExamplePhone2Y, DiagonalExamplePhone2Y, TechnologyExamplePhone2Y, ExamplePhone2, 1);
            Initialization(select, NameExamplePhone3Y, CodeExamplePhone3Y, PriceExamplePhone3, LinExamplePhone3Y, MemoryExamplePhone3Y, HardMemoryExamplePhone3Y, DiagonalExamplePhone3Y, TechnologyExamplePhone3Y, ExamplePhone3, 2);
        }
            public ExamplePhones()
            {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            select= "Select id_Товара, name, price, Image, Ruler, Memory, HardMemory, Diagonal, Тechnology From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Телефоны ON(ТИП_Товара.id = Телефоны.id)";
            
            Initialization(select,NameExamplePhone1Y, CodeExamplePhone1Y, PriceExamplePhone1, LinExamplePhone1Y, MemoryExamplePhone1Y, HardMemoryExamplePhone1Y, DiagonalExamplePhone1Y, TechnologyExamplePhone1Y, ExamplePhone1, 0);
            Initialization(select, NameExamplePhone2Y, CodeExamplePhone2Y, PriceExamplePhone2, LinExamplePhone2Y, MemoryExamplePhone2Y, HardMemoryExamplePhone2Y, DiagonalExamplePhone2Y, TechnologyExamplePhone2Y, ExamplePhone2, 1) ;
            Initialization(select, NameExamplePhone3Y, CodeExamplePhone3Y, PriceExamplePhone3, LinExamplePhone3Y, MemoryExamplePhone3Y, HardMemoryExamplePhone3Y, DiagonalExamplePhone3Y, TechnologyExamplePhone3Y, ExamplePhone3, 2);

             }

        private void Initialization(string select, TextBlock Name, TextBlock Code, TextBlock Price, TextBlock Lin, TextBlock Memory, TextBlock HardMemory, TextBlock Diagonal, TextBlock Techn, Image image, int i)
        {
            DataTable Goods = Select(select);
            Name.Text = Convert.ToString(Goods.Rows[i][1]);
            Code.Text = Convert.ToString(Goods.Rows[i][0]);
            Price.Text = " " + Convert.ToString(Goods.Rows[i][2]);
            Lin.Text = Convert.ToString(Goods.Rows[i][4]);
            Memory.Text = Convert.ToString(Goods.Rows[i][5]);
            HardMemory.Text = Convert.ToString(Goods.Rows[i][6]);
            Diagonal.Text = Convert.ToString(Goods.Rows[i][7]);
            Techn.Text = Convert.ToString(Goods.Rows[i][8]);

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

        private void BuyExamplePhone1(object sender, RoutedEventArgs e)
        {
            buy(NameExamplePhone1Y, PriceExamplePhone1, ExamplePhone1);
        }
        private void BuyExamplePhone2(object sender, RoutedEventArgs e)
        {
            buy(NameExamplePhone2Y, PriceExamplePhone2, ExamplePhone2);
        }
        private void BuyExamplePhone3(object sender, RoutedEventArgs e)
        {
            buy(NameExamplePhone3Y, PriceExamplePhone3, ExamplePhone3);
        }
    }
}
