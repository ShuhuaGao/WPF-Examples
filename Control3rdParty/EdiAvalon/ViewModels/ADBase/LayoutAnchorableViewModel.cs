using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace EdiAvalon.ViewModels.ADBase
{
    /// <summary>
    /// Contain properties related to <c>LayoutAnchorable</c>.
    /// </summary>
    /// <remarks>
    /// https://doc.xceed.com/xceed-toolkit-plus-for-wpf/Xceed.Wpf.AvalonDock~Xceed.Wpf.AvalonDock.Layout.LayoutAnchorable.html
    /// </remarks>
    public class LayoutAnchorableViewModel : LayoutContentViewModel
    {
        public LayoutAnchorableViewModel(string title = "Anchorable") : base(title)
        {
            IconSource = "/Assets/Images/tool-icon.png";
        }

        private bool isVisible = true;

        public bool IsVisible
        {
            get => isVisible;
            set
            {
                SetAndNotify(ref isVisible, value);
                //Debug.WriteLine($">> IsVisible: {value}");
            }
        }

    }
}
