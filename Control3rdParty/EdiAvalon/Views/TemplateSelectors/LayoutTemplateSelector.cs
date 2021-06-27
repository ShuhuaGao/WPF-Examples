using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace EdiAvalon.Views.TemplateSelectors
{
    /// <summary>
    /// Used as the <c>DockingManager.LayoutItemTemplateSelector</c> property
    /// </summary>
    /// https://doc.xceed.com/xceed-toolkit-plus-for-wpf/Xceed.Wpf.AvalonDock~Xceed.Wpf.AvalonDock.DockingManager~LayoutItemTemplateSelector.html
    public class LayoutTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// A <c>DataTemplate</c> to render a <see cref="EdiAvalon.ViewModels.FileViewModel"/>.
        /// We will define it in the XAML.
        /// </summary>
        public DataTemplate FileDataTemplate
        {
            get;
            set;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            return base.SelectTemplate(item, container);
        }
    }
}
