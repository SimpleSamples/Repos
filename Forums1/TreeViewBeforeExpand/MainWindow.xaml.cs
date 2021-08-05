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

namespace TreeViewBeforeExpand
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TreeViewItemSam tvi;
            tvi = new TreeViewItemSam();
            tvi.Header = "Root";
            TV1.Items.Insert(0, tvi);
            tvi = new TreeViewItemSam();
            tvi.Header = "Item";
            ((TreeViewItemSam)TV1.Items[0]).Items.Add(tvi);
        }

        private void ButtonExpand_Click(object sender, RoutedEventArgs e)
        {
            TV1.Nodes[0].Nodes[0].Expand();
        }
    }
}
