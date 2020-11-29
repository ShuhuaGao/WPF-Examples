using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.IO;

namespace TreeViewMVVM.ViewModel
{
    /// <summary>
    /// Represent the highest-level file system. Just as a wrapper to provide all drives.
    /// </summary>
    class FileSystemViewModel
    {
        public List<DirectoryItemViewModel> Drives { get; private set; } = new List<DirectoryItemViewModel>();

        public FileSystemViewModel()
        {
            foreach (var drive in DriveInfo.GetDrives())
            {
                // only hard disk and removable disk
                if (drive.DriveType == DriveType.Fixed || drive.DriveType == DriveType.Removable)
                {
                    Drives.Add(new DirectoryItemViewModel(drive.Name));
                }
            }
        }
    }
}
