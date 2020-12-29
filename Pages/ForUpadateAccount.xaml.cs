using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LAB33_KPIAP.Pages
{
    /// <summary>
    /// Логика взаимодействия для ForUpadateAccount.xaml
    /// </summary>
    public partial class ForUpadateAccount : Page
    {
        string connectionString;
        int ID;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        SqlConnection sqlConnection;
        public ForUpadateAccount(string id)
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            ID = Convert.ToInt32(id);

            Initialization(Name, Surname, Ott, Login, Pass);

        }


        private void Initialization(TextBox Name, TextBox Surname, TextBox Ott, TextBox Login, PasswordBox Pass)
        {
            DataTable Goods = Select($"Select Фамилия, Имя, Отчество, Login, Password FROM Покупатель WHERE id_Покупателя = {ID}");
            Name.Text = Convert.ToString(Goods.Rows[0][0]);
            Surname.Text = Convert.ToString(Goods.Rows[0][1]);
            Ott.Text = Convert.ToString(Goods.Rows[0][2]);
            Login.Text = Convert.ToString(Goods.Rows[0][3]);
            Pass.Password = Convert.ToString(Goods.Rows[0][4]);

        }
        public void UpdateData(object sender, RoutedEventArgs e)
        {
            try
            {

                DataTable Users = Select($"SELECT * FROM Покупатель WHERE Login ='{Login.Text}'");
                SqlCommand cmd;
                if (Users.Rows.Count == 0 && Pass.Password == Pass2.Password)
                {
                    sqlConnection = new SqlConnection(connectionString);
                    cmd = new SqlCommand();
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = $"UPDATE Покупатель SET Фамилия=N'{Name.Text}', Имя =N'{Surname.Text}', Отчество =N'{Ott.Text}', Login ='{Login.Text}',Password =N'{Pass.Password}' WHERE id_Покупателя = {ID}";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Успешно изменено");
                    Slaider2 slaider2 = new Slaider2();
                    this.NavigationService.Navigate(slaider2);

                }

                else
                {
                    MessageBox.Show("Пользователь с таким логином уже зарегестрирован.");
                }
            }
            catch
            {
                MessageBox.Show($"Данные были введены не верно!");
            }


        }

        public DataTable Select(string selectSQL)
        {
            dataTable = new DataTable();
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(selectSQL, sqlConnection);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception exec)
            {
                MessageBox.Show(exec.Message);
            }
            return dataTable;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MyPanel.Children.Clear();
            DataTable Tovars2 = Select($"SELECT id_Заказа,Date, количество_товаров,статус  FROM  Заказ WHERE id_Покупателя={ID}");
            for (int i = 0; i != Tovars2.Rows.Count; ++i)
            {

                TextBlock txtBlock = new TextBlock
                {
                    Text = $"id Заказа:{Tovars2.Rows[i][0]}\nДата заказа:{Tovars2.Rows[i][1]}\nКоличество товаров заказа:{Tovars2.Rows[i][2]}\nСтатус заказа:{Tovars2.Rows[i][3]}",

                };
                
                WrapPanel wr = new WrapPanel
                {
                    Width = 900,
                    Height = 110,
                    Margin = new Thickness(10),
                    Orientation = System.Windows.Controls.Orientation.Horizontal
                };
                wr.MouseEnter += (sendet, ert) =>
                {
                    wr.Background = Brushes.WhiteSmoke;
                };
                wr.MouseLeave += (sendet, ert) =>
                {
                    wr.Background = Brushes.White;
                };
                wr.Children.Add(txtBlock);
                MyPanel.Children.Add(wr);
            }

        }
    
    }
}
