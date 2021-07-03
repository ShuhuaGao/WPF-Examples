using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Diagnostics;
using AvalonDock.Layout;
using EdiAvalon.ViewModels.ADBase;

namespace EdiAvalon.Views.AD
{
    public class LayoutUpdateStrategy : ILayoutUpdateStrategy
    {
        public void AfterInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableShown)
        {
            Debug.WriteLine("AfterInsertAnchorable");

        }

        public void AfterInsertDocument(LayoutRoot layout, LayoutDocument anchorableShown)
        {
            Debug.WriteLine("AfterInsertDocument");

        }

        public bool BeforeInsertAnchorable(LayoutRoot layout, LayoutAnchorable anchorableToShow, ILayoutContainer destinationContainer)
        {
            Debug.WriteLine($"BeforeInsertAnchorable: {anchorableToShow.Title}, {anchorableToShow.Content}, {anchorableToShow.ContentId}");
            //return true;
            return BeforeInsertContent(layout, anchorableToShow);
        }

        public bool BeforeInsertDocument(LayoutRoot layout, LayoutDocument anchorableToShow, ILayoutContainer destinationContainer)
        {
            Debug.WriteLine($"BeforeInsertDocument: {anchorableToShow.Title}, {anchorableToShow.Content}, {anchorableToShow.ContentId}");
            //return true;
            return BeforeInsertContent(layout, anchorableToShow);
        }

        private bool BeforeInsertContent(LayoutRoot layout, LayoutContent anchorableToShow)
        {
            var viewModel = anchorableToShow.Content as LayoutContentViewModel;
            var temp = layout.Descendents().OfType<LayoutContent>().ToList();
            var layoutContent = temp.FirstOrDefault(x => x.ContentId == viewModel.ContentId);
            if (layoutContent == null)
                return false;
            layoutContent.Content = anchorableToShow.Content;
            // Add layoutContent to it's previous container
            var layoutContainer = layoutContent.GetType().GetProperty("PreviousContainer", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(layoutContent, null) as ILayoutContainer;
            if (layoutContainer is LayoutAnchorablePane)
                (layoutContainer as LayoutAnchorablePane).Children.Add(layoutContent as LayoutAnchorable);
            else if (layoutContainer is LayoutDocumentPane)
                (layoutContainer as LayoutDocumentPane).Children.Add(layoutContent);
            else
                throw new NotSupportedException();
            return true;
        }
    }
}
