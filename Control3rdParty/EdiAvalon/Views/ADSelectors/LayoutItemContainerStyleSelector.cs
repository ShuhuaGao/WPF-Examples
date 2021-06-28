using System;
using System.Collections.Generic;
using System.Linq;
using EdiAvalon.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace EdiAvalon.Views.ADSelectors
{
    /// <summary>
    /// Used to select the <c>Style</c> for a <c>LayoutItem</c> in Avalon dock.
    /// </summary>
    public class LayoutItemContainerStyleSelector : StyleSelector
    {
        #region these styles will be defined in XAML
        public Style ToolStyle { get; set; }
        public Style FileStyle { get; set; }
        public Style RecentFilesStyle { get; set; }
        #endregion

        /// <summary>
        /// Select a <c>Style</c> based on custom logic.
        /// </summary>
        /// <param name="item">the data object</param>
        /// <param name="container">the element to which the style will be applied.</param>
        /// <returns></returns>
        /// new C# syntax: expression body + switch expressions
        public override Style SelectStyle(object item, DependencyObject container) => item switch
        {
            FileViewModel => FileStyle,
            FileStatsViewModel => ToolStyle,
            _ => base.SelectStyle(item, container)
        };
    }
}
