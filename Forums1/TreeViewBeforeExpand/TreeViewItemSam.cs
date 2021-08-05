using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TreeViewBeforeExpand
{
    class TreeViewItemSam : TreeViewItem
    {
        protected override void OnExpanded(RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Expanding");
            base.OnExpanded(e);
        }
    }
}
