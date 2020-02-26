using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using DataAccess;
using MySql.Data.MySqlClient;

namespace DB_Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Database db;
        public MainWindow()
        {
            InitializeComponent();
            this.datagrid.AutoGenerateColumns = true;
            db = new Database();
            //txtServer.Text = "185.101.158.120";
            //txtDatabase.Text = "usr_web108_3";
            //txtUser.Text = "web108";
            //txtPassword.Text = "@gvH68uG5";
        }

        private void BtnGetTimes_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Input.Cursors.Wait;
                db.setConnData(txtServer.Text, txtDatabase.Text, txtUser.Text, txtPassword.Text);
                this.fillDatagrid();
                this.lblMessage.Content = "Times displayed in table!";
                this.Cursor = System.Windows.Input.Cursors.Arrow;
            }
            catch(MySqlException mysqlEx)
            {
                this.lblMessage.Content = "Can not connect to Server: " + mysqlEx.Message;
                this.Cursor = System.Windows.Input.Cursors.Arrow;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Input.Cursors.Arrow;
                this.lblMessage.Content = ex.Message;
            }
        }

        private void Datagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                this.Cursor = System.Windows.Input.Cursors.Wait;
                int row = e.Row.GetIndex();
                EasybaseTime editedTime = (EasybaseTime)datagrid.Items[row];
                DateTime dt;
                bool result = DateTime.TryParse(((System.Windows.Controls.TextBox)e.EditingElement).Text, out dt);

                if (result)
                    editedTime.exported = dt;
              
                int numUpdates = db.Update(editedTime);
                this.lblMessage.Content = numUpdates + " row(s) updated!";
                this.Cursor = System.Windows.Input.Cursors.Arrow;
            }
            catch (MySqlException mysqlEx)
            {
                this.lblMessage.Content = "Can not connect to Server: " + mysqlEx.ToString();
                this.Cursor = System.Windows.Input.Cursors.Arrow;
            }
            catch (Exception ex)
            {
                this.Cursor = System.Windows.Input.Cursors.Arrow;
                this.lblMessage.Content = ex.Message;
            }
        }

        private void Datagrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() != "exported")
                e.Column.IsReadOnly = true; // Makes the column as read only
        }

        private void fillDatagrid()
        {
            string compNr = this.txtCompanyNr.Text;
            string empNr = this.txtEmpNr.Text;
            List<EasybaseTime> times;
            if (!compNr.Equals("") && !empNr.Equals(""))
                times = db.Get(compNr, empNr);
            else
                if (!compNr.Equals("") && empNr.Equals(""))
                times = db.Get(compNr);
            else
                times = db.Get();

            CollectionViewSource source = new CollectionViewSource
            {
                Source = times
            };
            this.datagrid.ItemsSource = source.View;
            this.datagrid.Columns[4].CanUserSort = true;
        }

        private void btnCreateDB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                lblMessage.Content = "...";
                this.Cursor = System.Windows.Input.Cursors.Wait;
                db.SetUpserver(txtServer.Text, txtDatabase.Text, txtUser.Text, txtPassword.Text);
                lblMessage.Content = "Server is ready!";
                //if ()
                //    lblMessage.Content = "Server is ready!";
                //else
                //    lblMessage.Content = "Database already exsists!";
                this.Cursor = System.Windows.Input.Cursors.Arrow;
            }
            catch (MySqlException mysqlEx)
            {
                this.lblMessage.Content = "Can not connect to server: " + mysqlEx.Message;
                this.Cursor = System.Windows.Input.Cursors.Arrow;
            }
            catch (Exception ex)
            {
                this.lblMessage.Content = ex.Message;
                this.Cursor = System.Windows.Input.Cursors.Arrow;
            }
        }
    }
}
