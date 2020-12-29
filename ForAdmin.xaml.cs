using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace LAB33_KPIAP
{
    /// <summary>
    /// Логика взаимодействия для ForAdmin.xaml
    /// </summary>
    public partial class ForAdmin : Window
    {
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        string connectionString;
        public ForAdmin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
        private void Pokup_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                string select = "SELECT * FROM Покупатель";
                dataTable = new DataTable();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(select, sqlConnection);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);
                eGrid.ItemsSource = dataTable.DefaultView;
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            LogIn l = new LogIn();
            l.Show();
            this.Close();

        }
        private void Employeers_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                string select = "SELECT * FROM Сотрудник";
                dataTable = new DataTable();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(select, sqlConnection);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);
                eGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }
        private void Otmens_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                string select = "SELECT TOP(3) Фамилия,Имя, Отчество, Login, Count(количество_товаров) as [количество отмененных заказов] FROM Заказ JOIN Покупатель ON(Заказ.id_Покупателя = Покупатель.id_Покупателя) WHERE статус = N'отменен' Group by Фамилия,Имя, Отчество, Login Order by Count(количество_товаров) Desc";
                dataTable = new DataTable();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(select, sqlConnection);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);
                eGrid.ItemsSource = dataTable.DefaultView;
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = app.Documents.Add();
                
                switch(dataTable.Rows.Count)
                {
                    case 1:
                        var pText = doc.Paragraphs.Add();
                        pText.Range.Text = "\t\tПокупатели отменившие наибольшее кол-во заказов(ТОП 3)\n";
                        var pText2 = doc.Paragraphs.Add();
                        pText2.Range.Text += $"Фамилия заказчика:{dataTable.Rows[0][0]}\n";
                        var pText3 = doc.Paragraphs.Add();
                        pText3.Range.Text = $"Имя заказчика:{dataTable.Rows[0][1]}\n";
                        var pText4 = doc.Paragraphs.Add();
                        pText4.Range.Text = $"Отчество заказчика:{dataTable.Rows[0][2]}\n";
                        var pText5 = doc.Paragraphs.Add();
                        pText5.Range.Text = $"Login заказчика:{dataTable.Rows[0][3]}\n";
                        var pText6 = doc.Paragraphs.Add();
                        pText6.Range.Text = $"Количество отмененных заказов:{dataTable.Rows[0][4]}\n";
                        app.Visible = true;
                        break;
                    case 2:
                        var pTextN = doc.Paragraphs.Add();
                        pTextN.Range.Text = "\t\tПокупатели отменившие наибольшее кол-во заказов(ТОП 3)\n";
                        var pText2N = doc.Paragraphs.Add();
                        pText2N.Range.Text += $"Фамилия заказчика:{dataTable.Rows[0][0]}\n";
                        var pText3N = doc.Paragraphs.Add();
                        pText3N.Range.Text = $"Имя заказчика:{dataTable.Rows[0][1]}\n";
                        var pText4N = doc.Paragraphs.Add();
                        pText4N.Range.Text = $"Отчество заказчика:{dataTable.Rows[0][2]}\n";
                        var pText5N = doc.Paragraphs.Add();
                        pText5N.Range.Text = $"Login заказчика:{dataTable.Rows[0][3]}\n";
                        var pText6N = doc.Paragraphs.Add();
                        pText6N.Range.Text = $"Количество отмененных заказов:{dataTable.Rows[0][4]}\n";

                        var pText22 = doc.Paragraphs.Add();
                        pText22.Range.Text += $"Фамилия заказчика:{dataTable.Rows[1][0]}\n";
                        var pText23 = doc.Paragraphs.Add();
                        pText23.Range.Text = $"Имя заказчика:{dataTable.Rows[1][1]}\n";
                        var pText24 = doc.Paragraphs.Add();
                        pText24.Range.Text = $"Отчество заказчика:{dataTable.Rows[1][2]}\n";
                        var pText25 = doc.Paragraphs.Add();
                        pText25.Range.Text = $"Login заказчика:{dataTable.Rows[1][3]}\n";
                        var pText26 = doc.Paragraphs.Add();
                        pText26.Range.Text = $"Количество отмененных заказов:{dataTable.Rows[1][4]}\n";
                        app.Visible = true;
                        break;
                        
                    case 3:
                        var pTextY = doc.Paragraphs.Add();
                        pTextY.Range.Text = "\t\tПокупатели отменившие наибольшее кол-во заказов(ТОП 3)\n";
                        var pText2Y = doc.Paragraphs.Add();
                        pText2Y.Range.Text += $"Фамилия заказчика:{dataTable.Rows[0][0]}\n";
                        var pText3Y = doc.Paragraphs.Add();
                        pText3Y.Range.Text = $"Имя заказчика:{dataTable.Rows[0][1]}\n";
                        var pText4Y = doc.Paragraphs.Add();
                        pText4Y.Range.Text = $"Отчество заказчика:{dataTable.Rows[0][2]}\n";
                        var pText5Y = doc.Paragraphs.Add();
                        pText5Y.Range.Text = $"Login заказчика:{dataTable.Rows[0][3]}\n";
                        var pText6Y = doc.Paragraphs.Add();
                        pText6Y.Range.Text = $"Количество отмененных заказов:{dataTable.Rows[0][4]}\n";

                        var pText22Y = doc.Paragraphs.Add();
                        pText22Y.Range.Text += $"Фамилия заказчика:{dataTable.Rows[1][0]}\n";
                        var pText23Y = doc.Paragraphs.Add();
                        pText23Y.Range.Text = $"Имя заказчика:{dataTable.Rows[1][1]}\n";
                        var pText24Y = doc.Paragraphs.Add();
                        pText24Y.Range.Text = $"Отчество заказчика:{dataTable.Rows[1][2]}\n";
                        var pText25Y = doc.Paragraphs.Add();
                        pText25Y.Range.Text = $"Login заказчика:{dataTable.Rows[1][3]}\n";
                        var pText26Y = doc.Paragraphs.Add();
                        pText26Y.Range.Text = $"Количество отмененных заказов:{dataTable.Rows[1][4]}\n";
                        

                        var pText32 = doc.Paragraphs.Add();
                        pText32.Range.Text += $"Фамилия заказчика:{dataTable.Rows[2][0]}\n";
                        var pText33 = doc.Paragraphs.Add();
                        pText33.Range.Text = $"Имя заказчика:{dataTable.Rows[2][1]}\n";
                        var pText34 = doc.Paragraphs.Add();
                        pText34.Range.Text = $"Отчество заказчика:{dataTable.Rows[2][2]}\n";
                        var pText35 = doc.Paragraphs.Add();
                        pText35.Range.Text = $"Login заказчика:{dataTable.Rows[2][3]}\n";
                        var pText36 = doc.Paragraphs.Add();
                        pText36.Range.Text = $"Количество отмененных заказов:{dataTable.Rows[2][4]}\n";
                        app.Visible = true;
                        break;
                   default:
                        System.Windows.MessageBox.Show("Отмененных заказов нет");
                        break;
                }
                


                

                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }
            private void MoreBuy_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                string select = "SELECT TOP(3) Фамилия,Имя, Отчество, Login, SUM(количество_товаров) as [количество купленнех товаров] FROM Заказ JOIN Покупатель ON(Заказ.id_Покупателя = Покупатель.id_Покупателя) WHERE статус = N'выполнен' Group by Фамилия,Имя, Отчество, Login Order by SUM(количество_товаров) Desc";
                dataTable = new DataTable();
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(select, sqlConnection);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);
                eGrid.ItemsSource = dataTable.DefaultView;
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = app.Documents.Add();

                var pText = doc.Paragraphs.Add();
                pText.Range.Text = "\t\tПокупатели совершившие наибольшее кол-во покупок(ТОП 3)\n";
                var pText2 = doc.Paragraphs.Add();
                pText2.Range.Text += $"Фамилия заказчика:{dataTable.Rows[0][0]}\n";
                var pText3 = doc.Paragraphs.Add();
                pText3.Range.Text = $"Имя заказчика:{dataTable.Rows[0][1]}\n";
                var pText4 = doc.Paragraphs.Add();
                pText4.Range.Text = $"Отчество заказчика:{dataTable.Rows[0][2]}\n";
                var pText5 = doc.Paragraphs.Add();
                pText5.Range.Text = $"Login заказчика:{dataTable.Rows[0][3]}\n";
                var pText6 = doc.Paragraphs.Add();
                pText6.Range.Text = $"Количество совершенных покупок:{dataTable.Rows[0][4]}\n";
                

                var pText22 = doc.Paragraphs.Add();
                pText22.Range.Text += $"Фамилия заказчика:{dataTable.Rows[1][0]}\n";
                var pText23 = doc.Paragraphs.Add();
                pText23.Range.Text = $"Имя заказчика:{dataTable.Rows[1][1]}\n";
                var pText24 = doc.Paragraphs.Add();
                pText24.Range.Text = $"Отчество заказчика:{dataTable.Rows[1][2]}\n";
                var pText25 = doc.Paragraphs.Add();
                pText25.Range.Text = $"Login заказчика:{dataTable.Rows[1][3]}\n";
                var pText26 = doc.Paragraphs.Add();
                pText26.Range.Text = $"Количество совершенных покупок:{dataTable.Rows[1][4]}\n";
                

                var pText32 = doc.Paragraphs.Add();
                pText32.Range.Text += $"Фамилия заказчика:{dataTable.Rows[2][0]}\n";
                var pText33 = doc.Paragraphs.Add();
                pText33.Range.Text = $"Имя заказчика:{dataTable.Rows[2][1]}\n";
                var pText34 = doc.Paragraphs.Add();
                pText34.Range.Text = $"Отчество заказчика:{dataTable.Rows[2][2]}\n";
                var pText35 = doc.Paragraphs.Add();
                pText35.Range.Text = $"Login заказчика:{dataTable.Rows[2][3]}\n";
                var pText36 = doc.Paragraphs.Add();
                pText36.Range.Text = $"Количество совершенных покупок:{dataTable.Rows[2][4]}\n";

                app.Visible = true;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }

        private void Zakaz_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection sqlConnection = null;
            try
            {
                sqlConnection = new SqlConnection(connectionString);
                string select = "SELECT * FROM Заказ";
                dataTable = new DataTable();
                
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(select, sqlConnection);
                sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlDataAdapter.Fill(dataTable);
                eGrid.ItemsSource = dataTable.DefaultView;
                
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }
        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(sqlDataAdapter);
            sqlDataAdapter.Update(dataTable);
        }
        private void Update_Click(object sender, RoutedEventArgs e)
        {
            
            UpdateDB();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (eGrid.SelectedItems != null)
            {
                for (int i = 0; i < eGrid.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = eGrid.SelectedItems[i] as DataRowView;

                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;

                        dataRow.Delete();

                    }
                }

            }
            UpdateDB();
        }

        
    }
}
