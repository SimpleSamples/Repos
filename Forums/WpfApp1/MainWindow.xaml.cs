using System;
using System.Management;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StringBuilder sb = new StringBuilder();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuItemExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //SelectQuery q = new SelectQuery("SELECT * FROM Win32_DiskDrive Where InterfaceType='USB'");
            SelectQuery q = new SelectQuery("SELECT * FROM Win32_Process WHERE name='notepad.exe'");
            ManagementObjectSearcher s = new ManagementObjectSearcher(q);
            sb.Clear();
            //foreach (ManagementObject drive in s.Get())
            foreach (ManagementObject p in s.Get())
            {
                // sb.Append($"{drive["caption"]} | {drive["MediaType"]} | {drive["Model"]}\r\n");
                sb.Append($"{p["caption"]} | {p["Handle"]} | {p["CommandLine"]}\r\n");
            }
            InfoBox.Text = sb.ToString();
        }

        private void MenuItemCopy_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(sb.ToString());
        }
    }
}
