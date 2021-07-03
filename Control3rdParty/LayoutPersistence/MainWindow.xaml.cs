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
using System.Diagnostics;

namespace LayoutPersistence
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // we can change the xml content manually as long as it is legal for avalon
        private readonly string layoutXmlFile = "./layout2.xml";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Manager_Unloaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Serialize the layout...");
            var serializer = new AvalonDock.Layout.Serialization.XmlLayoutSerializer(this.Manager);
            serializer.Serialize(layoutXmlFile);
        }

        private void Manager_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Deserialize the layout...");
            var serializer = new AvalonDock.Layout.Serialization.XmlLayoutSerializer(this.Manager);
            // the handler is required even if it is empty
            serializer.LayoutSerializationCallback += Serializer_LayoutSerializationCallback;
            serializer.Deserialize(layoutXmlFile);
        }

        private void Serializer_LayoutSerializationCallback(object sender, AvalonDock.Layout.Serialization.LayoutSerializationCallbackEventArgs e)
        {
            //e.Model.Content = null;
        }
    }
}
