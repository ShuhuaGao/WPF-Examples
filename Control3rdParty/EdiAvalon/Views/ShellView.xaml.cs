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
            Debug.WriteLine(">> dockManager_Loaded");
            var vm = DataContext as ShellViewModel;
            vm.ActiveDocument = vm.Files[1];
        }
    }
}
