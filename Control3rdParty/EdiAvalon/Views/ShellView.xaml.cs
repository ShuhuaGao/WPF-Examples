using System.Windows;
using System.Diagnostics;
using EdiAvalon.ViewModels;

namespace EdiAvalon.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        public ShellView()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Debug.WriteLine("Window closed");
        }

        private void dockManager_Loaded(object sender, RoutedEventArgs e)
        {

        }

        // open menu item clicked
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                var filePath = dialog.FileName; // full path
                Debug.WriteLine(filePath);
                var vm = DataContext as ShellViewModel; // get view model
                vm?.OpenFile(filePath); // call viewmodel method like an action
            }
        }
    }
}
