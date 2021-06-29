using EdiAvalon.ViewModels.ADBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdiAvalon.ViewModels
{
    public class FileStatsViewModel : LayoutAnchorableViewModel
    {
        public FileStatsViewModel() : base("File Statistics")
        {
            ContentId = "FileStatsTool";
            IconSource = "./Assets/Images/property-blue.png";
        }


        private long _fileSize;

        public long FileSize
        {
            get => _fileSize;
            set => SetAndNotify(ref _fileSize, value);
        }

        private DateTime lastModified;

        public DateTime LastModified
        {
            get => lastModified;
            set => SetAndNotify(ref lastModified, value);
        }



    }
}
