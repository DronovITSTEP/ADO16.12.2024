using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ADO16._12._2024
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection conn = null;
        private SqlCommand cmd = null;
        private SqlDataAdapter adapter = null;

        private string stringConnection = "";
        private string query = "";
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void openData_Click(object sender, RoutedEventArgs e)
        {
            conn = new SqlConnection(stringConnection);
            cmd = conn.CreateCommand();
        }

        private void select1_click(object sender, RoutedEventArgs e)
        {
           /* // 1 вариант
            cmd = new SqlCommand("select * from table", conn);

            // 2 вариант
            cmd = new SqlCommand();
            cmd.CommandText = "select * from table";
            cmd.Connection = conn;

            // 3 вариант
            cmd = conn.CreateCommand();
            cmd.CommandText = "select * from table";*/

            dataGrid.ItemsSource = SelectCommand("");
        }
        private DataView SelectCommand(string query)
        {
            cmd.CommandText = query;
            adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable.DefaultView;
        }

        private DataView SelectCommand(string query, int param)
        {
            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@param", param);

            adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable.DefaultView;
        }
        private DataView SelectCommand(string query, string param)
        {
            cmd.CommandText = query;
            cmd.Parameters.Add("@param", SqlDbType.NVarChar, 20)
                .Value = param;

            adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            return dataTable.DefaultView;
        }
    }
}
