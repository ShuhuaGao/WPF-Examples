using Stylet;
using Zhaoxi.CourseManagement.Models;
using System.Diagnostics;

namespace Zhaoxi.CourseManagement.ViewModels
{
    public class MainViewModel : Conductor<IScreen>.Collection.OneActive
    {
        private string searchedText;  // text in the search box

        public string SearchedText
        {
            get => searchedText;
            set => SetAndNotify(ref searchedText, value);
        }

        private readonly FirstPageViewModel firstPageViewModel = new();
        private readonly CoursePageViewModel coursePageViewModel = new();

        public MainViewModel()
        {
            Items.Add(firstPageViewModel);
            Items.Add(new AboutUsPageViewModel());
            Items.Add(coursePageViewModel);
            // activate the first
            ActivateItem(firstPageViewModel);
            Debug.WriteLine($"Items length = {Items.Count}");
        }

        /// <summary>
        /// Activate a given item.
        /// </summary>
        /// <param name="i">index of the item in <see cref="Items"/></param>
        public void ActivateItemByIndex(string index)
        {
            //Debug.WriteLine($"Command: {index}");
            int i = int.Parse(index);
            if (i < Items.Count)
            {
                var item = Items[i];
                if (item != ActiveItem)
                    ActiveItem = item; // equiv to ActivateItem(item)
            }
        }
    }
}
