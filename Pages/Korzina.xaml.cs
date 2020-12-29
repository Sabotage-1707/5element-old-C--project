using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LAB33_KPIAP.Pages
{
    /// <summary>
    /// Логика взаимодействия для Korzina.xaml
    /// </summary>
    public partial class Korzina : Page
    {
        bool x = false;
        bool y = false;
        string connectionString;
        string Login;
        string Id;
        string PhoneNumber;
        string email;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        DateTime now;
        int id_Заказа;
        public Korzina(string login, string id)//
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Login = login;
            Id = id;

        }
        private void Delete(object sender, RoutedEventArgs e, int i)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(connectionString);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format("Delete from Korzina WHERE id = {0}", i);
            cmd.Connection = connection;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            MyPanel.Children.Clear();
            Load_Korz(sender, e);
        }
        private void Load_Korz(object sender, RoutedEventArgs e)
        {
            DataTable Tovars2 = Select("SELECT id,Name, Price, Image from Korzina Order BY id Desc");
            for (int i = Tovars2.Rows.Count - 1; i != -1; --i)
            {
                Image img = new Image
                {
                    Width = 100,
                    Height = 100,
                    Margin = new Thickness(3)
                };
                Grid grid = new Grid
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = System.Windows.HorizontalAlignment.Left
                };
                BitmapImage myBitmapImage = new BitmapImage();
                myBitmapImage.BeginInit();
                string path1 = Convert.ToString(Tovars2.Rows[i][3]);
                myBitmapImage.UriSource = new Uri($@"{path1}");
                myBitmapImage.EndInit();
                img.Source = myBitmapImage;
                System.Windows.Controls.Button deleteBtn = new System.Windows.Controls.Button
                {
                    Width = 100,
                    Height = 40,
                    Background = Brushes.Red,
                    Content = "delete"
                };
                string name = $"{Tovars2.Rows[i][1]}";
                if (name.Length > 35)
                {
                    name = name.Insert(35, "\n");
                }

                deleteBtn.Click += new RoutedEventHandler((send, ergs) => { Delete(send, ergs, Convert.ToInt32(Tovars2.Rows[i + 1][0])); });

                TextBlock txtBlock = new TextBlock
                {
                    Text = $"{i + 1}.{name}\n\n{Tovars2.Rows[i][2]} рублей",

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
                grid.Children.Add(deleteBtn);
                wr.Children.Add(img);
                wr.Children.Add(txtBlock);
                wr.Children.Add(grid);
                MyPanel.Children.Add(wr);
            }

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
        
        public void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton rb = sender as System.Windows.Controls.RadioButton;
            if (rb != null)
            {
                string profession = rb.Tag.ToString();
                switch (profession)
                {
                    case "Phone":
                        Change.Text = "Введите номер телефона:";
                        Confirm.Background = Brushes.Green;
                        break;

                    case "Email":
                        Change.Text = "Введите email:";
                        Confirm.Background = Brushes.Green;
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (Change.Text)
            {
                case "Введите номер телефона:":
                    Regex r = new Regex(@"^(\s*)?(\+)?([- _():=+]?\d[- _():=+]?){10,14}(\s*)?$");
                    if (r.IsMatch(box1.Text) == true)
                    {
                        x = true;
                        System.Windows.MessageBox.Show("Успешно подтвеждено");
                        y = true;
                        PhoneNumber = box1.Text;
                        box1.Text = "";
                        Zakaz.Background = Brushes.Red;

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Неверный номер телефона!");
                    }
                    break;
                case "Введите email:":
                    Regex r2 = new Regex(@"^[-a-zA-Z0-9!#$%&'*+/=?^_`{|}~]+(\.[-a-zA-Z0-9!#$%&'*+/=?^_`{|}~]+)*@([a-z0-9]([-a-z0-9]{0,61}[a-z0-9])?\.)*(aero|arpa|asia|biz|cat|com|coop|edu|gov|info|int|jobs|mil|mobi|museum|name|net|org|pro|tel|travel|[a-z][a-z])$");
                    if (r2.IsMatch(box1.Text) == true)
                    {
                        x = true;
                        System.Windows.MessageBox.Show("Успешно подтвеждено");
                        email = box1.Text;
                        box1.Text = "";
                        Zakaz.Background = Brushes.Red;
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Невереный email!");
                    }
                    break;
                default:
                    System.Windows.MessageBox.Show("Способ офомления заказа не выбран!");
                    break;
            }




        }
        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(sqlDataAdapter);
            sqlDataAdapter.Update(dataTable);
        }



        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            if (x == false)
            {
                System.Windows.MessageBox.Show("С начала выберете способ оформления заказа!");
            }
            else
            {
                try
                {
                    DataTable ForChek = Select("SELECT Name, Price from Korzina");
                    if(ForChek.Rows.Count != 0)
                    {
                        DataTable Users = Select($"SELECT Фамилия, Имя, Отчество From Покупатель WHERE id_Покупателя = {Convert.ToInt32(Id)}");
                        SqlCommand cmd = new SqlCommand();
                        SqlConnection connection = new SqlConnection(connectionString);
                        cmd.CommandType = System.Data.CommandType.Text;
                        now = DateTime.Now;
                        cmd.Parameters.AddWithValue("@Date", now);
                        cmd.CommandText = string.Format("INSERT INTO  Заказ(id_Покупателя, Date, количество_товаров, статус) VALUES ( {0} , @Date , {1}, N'в ожидании')", Convert.ToInt32(Id), ForChek.Rows.Count);
                        
                        cmd.Connection = connection;

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        cmd = new SqlCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "DELETE FROM Korzina";
                        cmd.Connection = connection;

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        DataTable orders = new DataTable();
                            SqlConnection sqlConnection = new SqlConnection(connectionString);
                            sqlConnection.Open();
                            SqlCommand sqlCommand = new SqlCommand($"SELECT * FROM Заказ where id_Покупателя = {Convert.ToInt32(Id)} AND Date = @dt AND количество_товаров = {ForChek.Rows.Count}", sqlConnection);
                            sqlCommand.Parameters.AddWithValue("@dt", now);
                            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                            sqlDataAdapter.Fill(orders);
                        cmd = new SqlCommand();
                        cmd.CommandType = System.Data.CommandType.Text;
                        Random r = new Random();
                        id_Заказа = Convert.ToInt32(orders.Rows[0][0]);
                        cmd.CommandText = string.Format("INSERT INTO Иметь(id_Сотрудника,id_Заказа) VALUES ({0},{1})", r.Next(1, 6), Convert.ToInt32(orders.Rows[0][0]));
                        cmd.Connection = connection;

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();

                        System.Windows.MessageBox.Show($"Спасибо за ваш заказ {Login}, ожидайте ответа.");
                        DialogResult res = System.Windows.Forms.MessageBox.Show("Печатать чек?", "Печать чека", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                        if (res == DialogResult.Yes)
                        {
                            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                            Microsoft.Office.Interop.Word.Document doc = app.Documents.Add();

                            var pText = doc.Paragraphs.Add();
                            pText.Range.Text = "\t\t\t\t\tЧек\n";
                            var pText2 = doc.Paragraphs.Add();
                            pText2.Range.Text += $"Фамилия заказчика:{Users.Rows[0][0]}\n";
                            var pText3 = doc.Paragraphs.Add();
                            pText3.Range.Text = $"Имя заказчика:{Users.Rows[0][1]}\n";
                            var pText4 = doc.Paragraphs.Add();
                            pText4.Range.Text = $"Отчество заказчика:{Users.Rows[0][2]}\n";
                            var pText5 = doc.Paragraphs.Add();
                            if (y == true)
                                pText5.Range.Text = $"Номер заказчика:{PhoneNumber}\n";
                            else
                                pText5.Range.Text = $"Email заказчика:{email}\n";

                            var pText6 = doc.Paragraphs.Add();
                            pText6.Range.Text = $"Id заказа:{id_Заказа}\n";
                            string str = "";
                            for (int i = 0; i != ForChek.Rows.Count; ++i)
                            {
                                str += $"{i + 1}.{ForChek.Rows[i][0]} {ForChek.Rows[i][1]}руб.\n";
                            }
                            var pText7 = doc.Paragraphs.Add();
                            pText7.Range.Text = $"Товары:\n{str}";
                            var pText8 = doc.Paragraphs.Add();
                            pText8.Range.Text = $"Время заказа:{now}\n";
                            var pText9 = doc.Paragraphs.Add();
                            pText9.Range.Text = $"Период времени в который можно забрать товар:{now} - {now.AddDays(2)}\n";
                            var pText10 = doc.Paragraphs.Add();
                            pText10.Range.Text = $"Адрес место выдачи товара:ул.Кульман,14\n";
                            var pText11 = doc.Paragraphs.Add();
                            pText11.Range.Text = $"Интернет-магазин 5 элемент, благодарит вас за заказ.";
                            app.Visible = true;

                        }

                        Slaider2 slaider2 = new Slaider2();
                        this.NavigationService.Navigate(slaider2);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Вы не выбрали товары!");
                    }
                    

                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                }
            }
        }


    }
}
