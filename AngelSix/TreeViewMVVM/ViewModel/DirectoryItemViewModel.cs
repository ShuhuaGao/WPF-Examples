using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.Specialized;

namespace TreeViewMVVM.ViewModel
{
    class DirectoryItemViewModel
    {
        private DirectoryInfo di;

        // in this example, we only need one-way binding for most properties because they will not be changed after construction
        public DirectoryItemType Type { get; private set; }
        public string FullPath { get; private set; }
        public string Name { get; private set; }
        public string ImageUri { get; private set; }
        public ICollection<DirectoryItemViewModel> Children { get; private set; } = new ObservableCollection<DirectoryItemViewModel>();

        // listen to the change of the property directly and no need to handle the expanded/collapsed event
        // Expanded event occurs when the IsExpanded property value changes from false to true.
        private bool isExpanded = false;
        public bool IsExpanded
        {
            get  // this part is never called since the binding mode is `OneWayToSource`
            {
                Debug.WriteLine("---IsExpanded get");
                return isExpanded;
            }
            set
            {
                if (!isExpanded && value)  // to expand
                {
                    Debug.WriteLine("IsExpanded set: false --> true");
                    SpawnChildren();

                }
                isExpanded = value;
            }
        }



        public DirectoryItemViewModel(string path)
        {
            di = new DirectoryInfo(path);
            FullPath = di.FullName;
            Name = di.Name;
            if (di.Attributes.HasFlag(FileAttributes.Directory))  // a folder or a drive
            {
                Type = di.Parent is null ? DirectoryItemType.Drive : DirectoryItemType.Folder;
            }
            else
            {
                Type = DirectoryItemType.File;
            }
            switch (Type)
            {
                case DirectoryItemType.Drive:
                    ImageUri = "pack://siteoforigin:,,,/images/drive.png";
                    break;
                case DirectoryItemType.File:
                    ImageUri = "pack://siteoforigin:,,,/images/file.png";
                    break;
                case DirectoryItemType.Folder:
                    ImageUri = "pack://siteoforigin:,,,/images/folder-closed.png";
                    break;
                default:
                    break;
            }
        }


        // refresh sub-folders and files 
        private void SpawnChildren()
        {
            Children.Clear();
            di.Refresh(); // in case the file system has been changed
            foreach (var info in di.EnumerateFileSystemInfos())
            {
                //Debug.WriteLine(info.Name);
                Children.Add(new DirectoryItemViewModel(info.FullName));
            }
        }




    }
}
