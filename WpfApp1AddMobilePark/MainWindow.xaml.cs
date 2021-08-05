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

namespace AddMobilePark1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ModelPark context = null;
        public MobilePark Park = null;

        public MainWindow()
        {
            InitializeComponent();
            Park = ((MobilePark)(FindResource("housingDataSet")));
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try { context = new ModelPark(); }
            catch (Exception ex)
            {
                MessageBox.Show($"Context creation failed: {ex.Message}");
                Close();
                return;
            }
        }

        private void MenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            if (context == null)
            {
                Message.Content = "No context";
            }
            try
            {
                int t;
                if (int.TryParse(feeTextBox.Text, out t))
                    Park.Fee = t;
                Park.Phone = phoneTextBox.Text;
                if (int.TryParse(fromLATextBox.Text, out t))
                    Park.FromLA = t;
                if (int.TryParse(countyIdTextBox.Text, out t))
                    Park.CountyId = t;
                Park.ParkName = parkNameTextBox.Text;
                Park.Comments = commentsTextBox.Text;
                context.MobileParks.Add(Park);
                Park = new MobilePark();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Context creation failed: {ex.Message}");
                Close();
                return;
            }
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
        }
    }
}
