using EdiAvalon.ViewModels.ADBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EdiAvalon.ViewModels
{
    public class FileStatsViewModel : LayoutAnchorableViewModel
    {
        public FileStatsViewModel() : base("File Statistics")
        {
            SetRawContentId("FileStatsTool");
            IconSource = "./Assets/Images/property-blue.png";
        }


        private long _fileSize;

        public long FileSize
        {
            get => _fileSize;
            set => SetAndNotify(ref _fileSize, value);
        }

        private DateTime lastModified = DateTime.MinValue;

        public DateTime LastModified
        {
            get => lastModified;
            set => SetAndNotify(ref lastModified, value);
        }


        private string filePath = "Not saved yet";

        public string FilePath
        {
            get => filePath;
            set
            {
                Debug.WriteLine($">> Set FilePath of FileStats: {value}");
                if (filePath != value)
                {
                    if (value == null)
                    {
                        filePath = "Not saved yet";
                        FileSize = 0;
                        LastModified = DateTime.MinValue;

                    }
                    else
                    {
                        filePath = value;
                        var fi = new FileInfo(filePath);
                        FileSize = fi.Length;
                        LastModified = fi.LastWriteTime;

                    }
                    NotifyOfPropertyChange();
                }

            }
        }


    }
}
