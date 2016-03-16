using System;
using System.Collections.Generic;
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

namespace Internship.PeopleDbBrowser
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.DataContext = this.DataContext;
            mainWindow.Show();


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            var dc =(Workspaces.MainWorkspace) this.DataContext;
            dc.Items.Add("new item " + dc.Items.Count);

            dc.DBName = "Settet from button";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var dc = (Workspaces.MainWorkspace)this.DataContext;
            dc.Items.Remove((string)((Button)sender).DataContext);

           // dc.DBName = "Settet from button";

        }
    }
}
