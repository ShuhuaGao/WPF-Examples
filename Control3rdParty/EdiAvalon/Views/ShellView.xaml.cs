using System.Windows;
using System.Diagnostics;
using System;
using System.IO;
using System.Xml;
using EdiAvalon.ViewModels;


namespace EdiAvalon.Views
{
    /// <summary>
    /// Interaction logic for ShellView.xaml
    /// </summary>
    public partial class ShellView : Window
    {
        private readonly string layoutXmlFile;

        public ShellView()
        {
            InitializeComponent();
            // set the path for the layout file
            string localAppDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string applicationName = Application.ResourceAssembly.GetName().Name;
            layoutXmlFile = Path.Combine(localAppDirectory, $"{applicationName}-AvalonDockLayout.xml");
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Debug.WriteLine("Window closed");
        }

        // load/restore the layout
        private void DockManager_Loaded(object sender, RoutedEventArgs e)
        {
            if (!File.Exists(layoutXmlFile))
            {
                Debug.WriteLine($"File not exists: {layoutXmlFile}");
                return;
            }
            // note that, in MVVM, the view can know the viewmodel (but not vice versa)
            if (DataContext is ShellViewModel vm)
            {
                // try to retrieve the viewmodel of a LayoutContent for the ContentId
                var serializer = new AvalonDock.Layout.Serialization.XmlLayoutSerializer(dockManager);
                serializer.LayoutSerializationCallback += RestoreLayoutContent;
                serializer.Deserialize(layoutXmlFile);
            }


        }

        private void RestoreLayoutContent(object sender, AvalonDock.Layout.Serialization.LayoutSerializationCallbackEventArgs args)
        {
            //Debug.WriteLine($">> Restore {args.Model.GetType()}, ContentId={args.Model.ContentId}, Title={args.Model.Title}");
            if (DataContext is ShellViewModel vm)
            {
                object content = vm.LocateContentFromId(args.Model.ContentId);
                if (content != null)
                    args.Model.Content = content;
                else
                    args.Cancel = true; // no need to show an empty pane
            }
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

        // save the layout
        private void DockManager_Unloaded(object sender, RoutedEventArgs e)
        {
            var serializer = new AvalonDock.Layout.Serialization.XmlLayoutSerializer(dockManager);
            serializer.Serialize(layoutXmlFile);
            Debug.WriteLine($">> Layout saved to {layoutXmlFile}");
        }
    }
}
