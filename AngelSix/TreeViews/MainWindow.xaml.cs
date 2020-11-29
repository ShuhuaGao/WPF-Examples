using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.IO;

namespace TreeViews
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
            // Directory.GetLogicalDrives() will get all drives including the floppy drive and any optical drives
            // we only want the hard disk and U-disk here
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.DriveType == DriveType.Fixed || drive.DriveType == DriveType.Removable)
                {
                    var item = new TreeViewItem();
                    item.Header = drive.Name; // C:\\
                    FolderView.Items.Add(item);
                    item.Tag = drive.Name; // full path, use `Tag` to store extra info
                    item.Expanded += Item_Expanded;
                    // to show the expander 
                    item.Items.Add(null);
                }

            }
            e.Handled = true;
        }

        private void Item_Expanded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Expanded");
            var item = sender as TreeViewItem;
            if (item.Tag is null)  // this is a file node
            {
                e.Handled = true;
                return;
            }

            item.Items.Clear();
            // full path of current item
            var fullPath = item.Tag as string;
            Debug.WriteLine($"Full path: {fullPath}");

            // sub directories
            foreach (var dir in Directory.GetDirectories(fullPath))
            {
                var subItem = new TreeViewItem()
                {
                    // Path.GetDirectoryName returns the *parent* directory name
                    Header = new DirectoryInfo(dir).Name,
                    Tag = dir // this is full path here
                };
                subItem.Items.Add(null);
                subItem.Expanded += Item_Expanded;
                item.Items.Add(subItem);
            }

            // files in the current directory
            foreach (var file in Directory.GetFiles(fullPath))
            {
                var subitem = new TreeViewItem();
                subitem.Header = Path.GetFileNameWithoutExtension(file);
                subitem.Tag = file;
                // no sub-item or expanded event for a file item
                item.Items.Add(subitem);
            }
            e.Handled = true;  // otherwise, the routed event will propogate to its ancestor TreeViewItem
        }
    }
}
