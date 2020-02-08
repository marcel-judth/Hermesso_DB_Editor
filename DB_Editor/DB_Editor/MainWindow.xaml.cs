using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DataAccess;


namespace DB_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.datagrid.AutoGenerateColumns = true;
        }

        private void btnGetTimes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string server = this.txtServer.Text;
                string database = this.txtDatabase.Text;
                string user = this.txtUser.Text;
                string password = this.txtPassword.Text;
                string compNr = this.txtCompanyNr.Text;

                server = "185.101.158.120";
                database = "usr_web108_3";
                user = "web108";
                password = "@gvH68uG5";
                compNr = "1234";

                List<EasybaseTime> times = Database.get(server, database, user, password, compNr);
                var bindingList = new BindingList<EasybaseTime>(times);
                var source = new BindingSource(bindingList, null);
                this.datagrid.ItemsSource = source;
                this.lblMessage.Content = "Data loaded!";
            }catch (Exception ex)
            {
                this.lblMessage.Content = ex.ToString();
            }
        }

        private void datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
                
        }
    }
}
