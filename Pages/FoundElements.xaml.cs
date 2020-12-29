using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LAB33_KPIAP.Pages
{
    /// <summary>
    /// Логика взаимодействия для FoundElements.xaml
    /// </summary>
    public partial class FoundElements : Page
    {
        string SelectSQL;
        string connectionString;
        public FoundElements(string select)
        {
            InitializeComponent();
            SelectSQL = select;
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            Initialization2();
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

        private void InitTovar(int i, TextBlock txtBlock, StackPanel stck)
        {
            DataTable Phones = Select("Select * From Товар " +
            $"Where Товар.name Like '%{SelectSQL}%'");
            Image img = new Image
            {
                Width = 287,
                Height = 196,
                Margin = new Thickness(3)
            };
            BitmapImage myBitmapImage = new BitmapImage();
            myBitmapImage.BeginInit();
            string path1 = Convert.ToString(Phones.Rows[i][3]);
            myBitmapImage.UriSource = new Uri($@"{path1}");
            myBitmapImage.EndInit();
            img.Source = myBitmapImage;

            TextBlock textBlock = new TextBlock
            {
                Height = 69,
                FontWeight = FontWeights.DemiBold,
                Text = $"{Phones.Rows[i][2]}",
                FontSize = 20
            };
            System.Windows.Controls.Button btn = new System.Windows.Controls.Button
            {
                Height = 62,
                Content = "Buy",
                Background = Brushes.LemonChiffon

            };
            


            btn.Click += new RoutedEventHandler((send, ergs) =>
            {
                buy(send, ergs, Convert.ToString(Phones.Rows[i][1]), Convert.ToString(Phones.Rows[i][2]), Convert.ToString(Phones.Rows[i][3]));
            });
            StackPanel stackPanel = new StackPanel
            {
                Height = 192,
                Width = 104
            };
            stackPanel.Children.Add(textBlock);
            stackPanel.Children.Add(btn);

            WrapPanel wr = new WrapPanel
            {
                Width = 1352,
                Height = 213,
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

            wr.Children.Add(img);
            wr.Children.Add(txtBlock);
            wr.Children.Add(stck);
            wr.Children.Add(stackPanel);
            MyPanel.Children.Add(wr);
        }
        private TextBlock TextBlockForPhons()
        {

            TextBlock textBlock = new TextBlock
            {
                Height = 200,
                Width = 186,
                Text = "Название\nКод\nЛинейка\nОбъем встроенной памяти\nОбъем оперативной памяти\nДиагональ экрана\nТехнология экрана",
                FontSize = 14
            };
            return textBlock;
        }
        private TextBlock TextBlockForHeadPhones()
        {

            TextBlock textBlock = new TextBlock
            {
                Height = 200,
                Width = 186,
                Text = "Название\nКод\nВид устройства\nТип подключенияи\nКонструкция наушников",
                FontSize = 14
            };
            return textBlock;
        }
        private TextBlock TextBlockForPristavki()
        {

            TextBlock textBlock = new TextBlock
            {
                Height = 200,
                Width = 186,
                Text = "Название\nКод\nСуммарная мощность\nUSB\nBluetooth",
                FontSize = 14
            };
            return textBlock;
        }
        private TextBlock TextBlockForConsoles()
        {

            TextBlock textBlock = new TextBlock
            {
                Height = 200,
                Width = 186,
                Text = "Название\nКод\nТип\nПоддерживаемые носители\nWifi",
                FontSize = 14
            };
            return textBlock;
        }
        private TextBlock TextBlockForTV()
        {

            TextBlock textBlock = new TextBlock
            {
                Height = 200,
                Width = 186,
                Text = "Название\nКод\nДиагональ\nРазрешение\nSmart TV",
                FontSize = 14
            };
            return textBlock;
        }
        private TextBlock TextBlockForPads()
        {

            TextBlock textBlock = new TextBlock
            {
                Height = 200,
                Width = 186,
                Text = "Название\nКод\nТип оперционной системы\nОбъем встроенной памяти\nОбъем оперативной памяти\nДиагональ экрана\nТип Матрицы",
                FontSize = 14
            };
            return textBlock;
        }
        private TextBlock TextBlockForNoutbooks()
        {

            TextBlock textBlock = new TextBlock
            {
                Height = 200,
                Width = 186,
                Text = "Название\nКод\nСерия\nТип оперционной системы\nТип видеокарты\nОбъем оперативной памяти\nСерия процессора\nТип жесткого диска",
                FontSize = 14
            };
            return textBlock;
        }
        private StackPanel StackPanelForHeadPhones(int id_Type)
        {
            DataTable Phones = Select($"Select id_Товара, name, price, Image, x.Device_Type, x.Connection_Type, x.Device_Construction From Товар JOIN (SELECT ТИП_Товара.id, Device_Type, Connection_Type, Device_Construction FROM ТИП_Товара JOIN Наушники ON(ТИП_Товара.id = Наушники.id)) x ON(x.id = Товар.id_Type) WHERE Товар.id_Type = {id_Type}");

            StackPanel newstack = new StackPanel
            {
                Height = 199,
                Width = 457
            };
            TextBlock textBlock0 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][1]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock1 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][0]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock2 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][4]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock3 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][5]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock4 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][6]}",
                FontSize = 14,
                Width = 457
            };
            
            newstack.Children.Add(textBlock0);
            newstack.Children.Add(textBlock1);
            newstack.Children.Add(textBlock2);
            newstack.Children.Add(textBlock3);
            newstack.Children.Add(textBlock4);
            return newstack;
        }
        private StackPanel StackPanelForNoutbooks(int id_Type)
        {
            DataTable Phones = Select($"Select id_Товара, name, price, Image, Seria, TypeSystem,  VideoKart_Type, HardMemory, Seria_Proc, HardDrive From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Ноутбуки ON(ТИП_Товара.id = Ноутбуки.id) WHERE Товар.id_Type = {id_Type}");

            StackPanel newstack = new StackPanel
            {
                Height = 199,
                Width = 457
            };
            TextBlock textBlock0 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][1]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock1 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][0]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock2 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][4]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock3 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][5]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock4 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][6]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock5 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][7]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock6 = new TextBlock
            {
                Height = 18,
                Text = $"{Phones.Rows[0][8]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock7 = new TextBlock
            {
                Height = 18,
                Text = $"{Phones.Rows[0][9]}",
                FontSize = 14,
                Width = 457
            };
            newstack.Children.Add(textBlock0);
            newstack.Children.Add(textBlock1);
            newstack.Children.Add(textBlock2);
            newstack.Children.Add(textBlock3);
            newstack.Children.Add(textBlock4);
            newstack.Children.Add(textBlock5);
            newstack.Children.Add(textBlock6);
            newstack.Children.Add(textBlock7);
            return newstack;
        }
        private StackPanel StackPanelForPhons(int id_Type)
            {
            DataTable Phones = Select($"Select id_Товара, name, price, Image, Ruler, Memory, HardMemory, Diagonal, Тechnology From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Телефоны ON(ТИП_Товара.id = Телефоны.id) WHERE Товар.id_Type = {id_Type}");

            StackPanel newstack = new StackPanel
            {
                Height = 199,
                Width = 457
            };
            TextBlock textBlock0 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][1]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock1 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][0]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock2 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][4]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock3 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][5]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock4 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][6]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock5 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][7]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock6 = new TextBlock
            {
                Height = 18,
                Text = $"{Phones.Rows[0][8]}",
                FontSize = 14,
                Width = 457
            };
            newstack.Children.Add(textBlock0);
            newstack.Children.Add(textBlock1);
            newstack.Children.Add(textBlock2);
            newstack.Children.Add(textBlock3);
            newstack.Children.Add(textBlock4);
            newstack.Children.Add(textBlock5);
            newstack.Children.Add(textBlock6);
            return newstack;
        }
        private StackPanel StackPanelForPads(int id_Type)
        {
            DataTable Phones = Select($"Select id_Товара, name, price, Image, x.System_Type, x.Memory, x.HardMemory, x.Diagonal, Matrix From Товар JOIN (SELECT ТИП_Товара.id, System_Type, Memory, HardMemory, Diagonal, Matrix FROM ТИП_Товара JOIN Планшеты ON(ТИП_Товара.id = Планшеты.id)) x ON(x.id = Товар.id_Type) WHERE Товар.id_Type = {id_Type}");

            StackPanel newstack = new StackPanel
            {
                Height = 199,
                Width = 457
            };
            TextBlock textBlock0 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][1]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock1 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][0]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock2 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][4]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock3 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][5]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock4 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][6]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock5 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][7]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock6 = new TextBlock
            {
                Height = 18,
                Text = $"{Phones.Rows[0][8]}",
                FontSize = 14,
                Width = 457
            };
            newstack.Children.Add(textBlock0);
            newstack.Children.Add(textBlock1);
            newstack.Children.Add(textBlock2);
            newstack.Children.Add(textBlock3);
            newstack.Children.Add(textBlock4);
            newstack.Children.Add(textBlock5);
            newstack.Children.Add(textBlock6);
            return newstack;
        }
        private StackPanel StackPanelForTV(int id_Type)
        {
            DataTable Phones = Select($"Select id_Товара, name, price, Image, Diagonal, Razreshenie, Smart_TV From Товар " +
                $"JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Телевизоры ON(ТИП_Товара.id = Телевизоры.id)WHERE Товар.id_Type = {id_Type}");

            StackPanel newstack = new StackPanel
            {
                Height = 199,
                Width = 457
            };
            TextBlock textBlock0 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][1]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock1 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][0]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock2 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][4]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock3 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][5]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock4 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][6]}",
                FontSize = 14,
                Width = 457
            };
            newstack.Children.Add(textBlock0);
            newstack.Children.Add(textBlock1);
            newstack.Children.Add(textBlock2);
            newstack.Children.Add(textBlock3);
            newstack.Children.Add(textBlock4);
            return newstack;
        }
        private StackPanel StackPanelForPristavki(int id_Type)
        {
            DataTable Phones = Select($"Select id_Товара, name, price, Image, x.Power, x.USB, x.Bluetooth From Товар JOIN (SELECT ТИП_Товара.id, Power, USB, Bluetooth FROM ТИП_Товара JOIN Видеотехника ON(ТИП_Товара.id = Видеотехника.id)) x ON(x.id = Товар.id_Type) WHERE Товар.id_Type = {id_Type}");

            StackPanel newstack = new StackPanel
            {
                Height = 199,
                Width = 457
            };
            TextBlock textBlock0 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][1]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock1 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][0]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock2 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][4]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock3 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][5]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock4 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][6]}",
                FontSize = 14,
                Width = 457
            };
            newstack.Children.Add(textBlock0);
            newstack.Children.Add(textBlock1);
            newstack.Children.Add(textBlock2);
            newstack.Children.Add(textBlock3);
            newstack.Children.Add(textBlock4);
            return newstack;
        }
        private StackPanel StackPanelForConsoles(int id_Type)
        {
            DataTable Phones = Select($"Select id_Товара, name, price, Image, Type, Nositeli, Wifi From Товар JOIN ТИП_Товара ON(ТИП_Товара.id = Товар.id_Type) JOIN Приставки ON(ТИП_Товара.id = Приставки.id) WHERE Товар.id_Type = {id_Type}");

            StackPanel newstack = new StackPanel
            {
                Height = 199,
                Width = 457
            };
            TextBlock textBlock0 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][1]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock1 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][0]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock2 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][4]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock3 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][5]}",
                FontSize = 14,
                Width = 457
            };
            TextBlock textBlock4 = new TextBlock
            {
                Height = 16,
                Text = $"{Phones.Rows[0][6]}",
                FontSize = 14,
                Width = 457
            };
            newstack.Children.Add(textBlock0);
            newstack.Children.Add(textBlock1);
            newstack.Children.Add(textBlock2);
            newstack.Children.Add(textBlock3);
            newstack.Children.Add(textBlock4);
            return newstack;
        }
        public void Initialization2()
        {
            try
            {

          
            DataTable dataTable = new DataTable();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand($"Select * From Товар " +
            $"Where Товар.name Like N'%{SelectSQL}%' OR Товар.name Like N'{SelectSQL}%'", sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i != dataTable.Rows.Count; ++i)
                {
                    switch (dataTable.Rows[i][4])
                    {
                        case 1:
                        case 2:
                        case 3:
                            InitTovar(i, TextBlockForPhons(), StackPanelForPhons(Convert.ToInt32(dataTable.Rows[i][4])));
                            break;
                        case 4:
                        case 5:
                        case 6:
                            InitTovar(i, TextBlockForPristavki(), StackPanelForPristavki(Convert.ToInt32(dataTable.Rows[i][4])));
                            break;
                        case 7:
                        case 8:
                        case 9:
                            InitTovar(i, TextBlockForNoutbooks(), StackPanelForNoutbooks(Convert.ToInt32(dataTable.Rows[i][4])));
                            break;
                        case 10:
                        case 11:
                        case 12:
                            InitTovar(i, TextBlockForPads(), StackPanelForPads(Convert.ToInt32(dataTable.Rows[i][4])));
                            break;
                        case 13:
                        case 14:
                        case 15:
                            InitTovar(i, TextBlockForHeadPhones(), StackPanelForHeadPhones(Convert.ToInt32(dataTable.Rows[i][4])));
                            break;
                        case 16:
                        case 17:
                        case 18:
                            InitTovar(i, TextBlockForConsoles(), StackPanelForConsoles(Convert.ToInt32(dataTable.Rows[i][4])));
                           
                            break;
                        case 19:
                        case 20:
                        case 21:
                            InitTovar(i, TextBlockForTV(), StackPanelForTV(Convert.ToInt32(dataTable.Rows[i][4])));
                            break;

                    }
                }
            }
                else
                {
                    System.Windows.MessageBox.Show($"\tОшибка!\nНичего не найдено");
                }

            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
        
        private void buy(object sender, RoutedEventArgs e,string Name, string Price, string image)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection connection = new SqlConnection(connectionString);
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = string.Format("INSERT INTO  Korzina( Image, Name , Price ) VALUES (N'{0}', N'{1}' , N'{2}')", image, Name, Price);
            cmd.Connection = connection;

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
            System.Windows.MessageBox.Show($"Добавлено в корзину");

        }
    }

}
