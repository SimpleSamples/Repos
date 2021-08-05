using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Hwnd handle = Process.GetCurrentProcess().MainWindowHandle;
            IntPtr handle = Process.GetCurrentProcess().MainWindowHandle;
            // parameters.ParentWindow = handle;
            System.Windows.Interop.HwndSourceParameters parameters;
            parameters.ParentWindow = handle;
            HwndSource src = new HwndSource(parameters);
            src.RootVisual = view;
            HwndSource src2 = HwndSource.FromHwnd(handle); // return null
        }
    }
}
