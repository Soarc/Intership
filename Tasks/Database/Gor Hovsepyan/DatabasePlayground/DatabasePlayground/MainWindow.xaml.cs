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


namespace DatabasePlayground
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

       async private void ExecuteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var builder = new SqlConnectionStringBuilder();
                builder.DataSource = serverIdTxt.Text;
               
                builder.IntegratedSecurity = SqlradioButton.IsChecked != null ? SqlradioButton.IsChecked.Value : false;
                if(!builder.IntegratedSecurity)
                {
                    builder.UserID = LoginTxt.Text;
                    builder.Password = PassTxt.Text;
                }
                //
                builder.InitialCatalog = Databasetxt.Text;
                status.Text = "Connecting to Database";
                SqlConnection conn = new SqlConnection(builder.ConnectionString);
                await  conn.OpenAsync();
                status.Text = "Executing SQLCommand";    
                
                var query = CommandTxt.Text;
                SqlCommand comm = new SqlCommand(query, conn);
                var reader =await comm.ExecuteReaderAsync();

                var result = new DataTable();  

                //
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    result.Columns.Add(reader.GetName(i));
                }

                while(await reader.ReadAsync())
                {
                    var row = result.NewRow();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }
                    result.Rows.Add(row);
                }
                conn.Close();
                conn.Dispose();

                dataGrid.ItemsSource = result.DefaultView;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
