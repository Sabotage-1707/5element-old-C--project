using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace LAB33_KPIAP
{

    public partial class LogIn : Window
    {
        string connectionString;
        public LogIn()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(connectionString);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "DROP TABLE IF EXISTS Korzina;";//удаление таблица Корзина из Бд
            cmd.Connection = connection;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();

            cmd = new SqlCommand();
            connection = new SqlConnection(connectionString);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "CREATE TABLE Korzina(id int IDENTITY(1,1),[Image] nvarchar(255) NOT NULL, [Name] nvarchar(255) NOT NULL,Price nvarchar(30) NOT NULL)";//создание таблицы корзина в бд
            cmd.Connection = connection;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount f = new CreateAccount();//переход в создания аккаунта
            f.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool x = true;
            DataTable dt_User = Select("SELECT Login, Password, id_Покупателя From Покупатель");
            if (Login.Text == "Loli" && Pass.Password == "12345678")
            {
                ForAdmin f = new ForAdmin();
                f.Show();
                this.Close();
                x = false;
            }
            for (int i = 0; i != dt_User.Rows.Count; ++i)
            {

                if (Login.Text == Convert.ToString(dt_User.Rows[i][0]) && Pass.Password == Convert.ToString(dt_User.Rows[i][1]))//проверка на совпадение логина и пароля
                {
                    MainWindow m = new MainWindow(Login.Text, Convert.ToString(dt_User.Rows[i][2]));
                    m.Show();
                    this.Close();
                    x = false;
                }

            }
            if (x == true)
                MessageBox.Show("Неверный логин или пароль");

        }
        public DataTable Select(string selectSQL)//создание DataTable
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
    }
}
