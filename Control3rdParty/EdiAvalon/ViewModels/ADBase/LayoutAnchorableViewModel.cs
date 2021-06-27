using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public LayoutAnchorableViewModel(string title) : base(title)
        {
        }
    }
}
