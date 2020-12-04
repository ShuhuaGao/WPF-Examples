using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace Fasetto.Word.Views
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

        private void IconButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(appWindow);
            var posScreen = appWindow.PointToScreen(pos);
            Debug.WriteLine($"Pos: {pos}. Pos on screen: {posScreen}");
            SystemCommands.ShowSystemMenu(appWindow, posScreen);
        }

        private void minimizeWindow(object sender, RoutedEventArgs e) => this.WindowState = WindowState.Minimized;


        private void maximizeWindow(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;

            }
            else
            {
                this.WindowState = WindowState.Normal;

            }
        }

        private void closeWindow(object sender, RoutedEventArgs e) => Close();

    }
}
