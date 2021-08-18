using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
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

namespace DataGridWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionstring = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=G:\Sam\Documents\db1.mdb";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            OleDbConnection Connection = new OleDbConnection(connectionstring);
            Connection.Open();
            OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM Stores", Connection);
            DataSet myDataSet = new DataSet();
            adapter.Fill(myDataSet, "Stores");
            Grid.DataContext = myDataSet;
            Grid.ItemsSource = myDataSet.Tables[0].DefaultView;
        }
    }
}
