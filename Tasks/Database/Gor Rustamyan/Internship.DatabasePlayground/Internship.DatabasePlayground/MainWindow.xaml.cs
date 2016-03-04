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

namespace Internship.DatabasePlayground
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        async void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = txtDataSource.Text;
                builder.IntegratedSecurity = rbtnIntegratedSecurity.IsChecked != null ? rbtnIntegratedSecurity.IsChecked.Value : false;
                if (!builder.IntegratedSecurity)
                {
                    builder.UserID = txtLogin.Text;
                    builder.Password = txtPassword.Text;
                }

                builder.InitialCatalog = txtInitialCatalog.Text;

                status.Text = "Connecting to DB";
                var connection = new SqlConnection(builder.ConnectionString);
                await connection.OpenAsync();


                status.Text = "Executing query";
                var query = txtQuery.Text;

                var command = new SqlCommand(query, connection);
                var reader = await command.ExecuteReaderAsync();

                var result = new DataTable();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result.Columns.Add(reader.GetName(i));
                }

                while (await reader.ReadAsync())
                {

                    var row = result.NewRow();

                    for (int i = 0; i < reader.FieldCount; i++)
                        row[i] = reader[i];

                    result.Rows.Add(row);


                }

                connection.Close();
                connection.Dispose();


                dataGrid.ItemsSource = result.DefaultView;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
    }
}
