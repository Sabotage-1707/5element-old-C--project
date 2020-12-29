using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;

namespace LAB33_KPIAP
{
    /// <summary>
    /// Логика взаимодействия для CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        string connectionString;
        public CreateAccount()
        {
            InitializeComponent();
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
                MessageBox.Show(exec.Message);
            }
            return dataTable;

        }
        private void Create_Click(object sender, RoutedEventArgs e)
        {
            if (First.Text == "" || Second.Text == "" || Third.Text == "" || Fourth.Text == "" || Fifth.Password == "" || Sixth.Password == "")
            {
                MessageBox.Show("Необходимо заполнить все поля!!!");

            }
            else
            {
                if (Fifth.Password != Sixth.Password)
                {
                    MessageBox.Show("Пароли не совпадают");
                    Fifth.Password = null;
                    Sixth.Password = null;
                }
                else
                {
                    Regex r2 = new Regex(@"^([А-Я]{1}[а-яё]{1,23}|[A-Z]{1}[a-z]{1,23})$");
                    Regex r = new Regex(@"^(\w+){3,20}$");
                    if (r2.IsMatch(First.Text) == true && r2.IsMatch(Second.Text) == true && r2.IsMatch(Third.Text) == true && r.IsMatch(Fourth.Text) == true)
                    {
                        string Surname = First.Text;
                        string Name = Second.Text;
                        string Ottchestvo = Third.Text;
                        string Login = Fourth.Text;
                        string Password = Fifth.Password;
                        string password2 = Sixth.Password;
                        SqlCommand cmd = new SqlCommand();
                        SqlConnection connection = new SqlConnection(connectionString);
                        DataTable Users = Select($"SELECT * FROM Покупатель WHERE Login = '{Login}'");
                        if (Users.Rows.Count == 0)
                        {
                            cmd = new SqlCommand();
                            cmd.CommandType = System.Data.CommandType.Text;
                            cmd.CommandText = string.Format("INSERT INTO  Покупатель(Фамилия, Имя, Отчество, Login, Password) VALUES (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", Surname, Name, Ottchestvo, Login, Password);
                            cmd.Connection = connection;

                            connection.Open();
                            cmd.ExecuteNonQuery();
                            connection.Close();
                            MessageBox.Show($"Аккаунт успешно создан");
                            LogIn log = new LogIn();
                            log.Show();
                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином уже существует.");
                            Fourth.Text = null;
                            Fifth.Password = null;
                            Sixth.Password = null;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Неверный формат Фамилии или Имени или Отчества");
                    }

                }

            }

        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LogIn l = new LogIn();//переход в окно Login
            l.Show();
            this.Close();

        }
    }
}
