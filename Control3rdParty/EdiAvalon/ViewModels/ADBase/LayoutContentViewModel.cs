using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stylet;


namespace EdiAvalon.ViewModels.ADBase
{
    /// <summary>
    /// Some properties corresponding to <c>LayoutContent</c>.
    /// </summary>
    /// <remarks>
    /// https://doc.xceed.com/xceed-toolkit-plus-for-wpf/Xceed.Wpf.AvalonDock~Xceed.Wpf.AvalonDock.Layout.LayoutContent_members.html
    /// </remarks>
    public class LayoutContentViewModel : PropertyChangedBase
    {
        public LayoutContentViewModel(string title)
        {
            Title = title;
        }

        private string title;

        public string Title
        {
            get => title;
            set => SetAndNotify(ref title, value);
        }


        public string IconSource
        {
            get;
            protected set;
        }

        private string contentId;

        /// <summary>
        /// Get the ID of the content, which is used to identify the content during serialization/deserialization.
        /// </summary>
        public string ContentId
        {
            get => contentId;
            private set => SetAndNotify(ref contentId, value);
        }

        /// <summary>
        /// Set the content ID with the class name as the prefix.
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="prefix">a short string inserted before <paramref name="id"/></param>
        /// <remarks>
        /// The resultant content ID is <c>className + "|" + <paramref name="id"/> </c>, which can be obtained by <seealso cref="ContentId"/>,
        /// where <c>className</c> is the name of the current class.
        /// </remarks>
        public void SetRawContentId(string rawId)
        {
            ContentId = $"{GetType().Name}|{rawId}";
        }



        private bool isSelected;

        /// <summary>
        /// Gets or sets whether a content element is selected.
        /// </summary>
        /// <remarks>
        /// https://doc.xceed.com/xceed-toolkit-plus-for-wpf/Xceed.Wpf.AvalonDock~Xceed.Wpf.AvalonDock.Layout.LayoutContent~IsSelected.html
        /// Many LayoutContents could be selected in a DockingManager.
        /// </remarks>
        public bool IsSelected
        {
            get => isSelected;
            set => SetAndNotify(ref isSelected, value);
        }

        private bool isActive;

        /// <summary>
        /// Gets or sets whether the content is active.
        /// </summary>
        /// <remarks>
        /// Only one LayoutContent can be active in a DockingManager in contrast to <seealso cref="IsSelected"/>
        /// </remarks>
        public bool IsActive
        {
            get => isActive;
            set => SetAndNotify(ref isActive, value);
        }
    }
}
