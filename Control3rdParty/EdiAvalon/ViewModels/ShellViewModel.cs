using System.Collections.Generic;
using System.Collections.ObjectModel;
using Stylet;
using EdiAvalon.ViewModels.ADBase;
using System.Linq;
using System.Diagnostics;

namespace EdiAvalon.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ObservableCollection<FileViewModel> Files { get; set; } = new ObservableCollection<FileViewModel>();

        public ShellViewModel()
        {
            Files.Add(new FileViewModel { Title = "file 1" });
            Files.Add(new FileViewModel { Title = "file 2" });
            Files.Add(new FileViewModel { Title = "file 3" });
            ActiveDocument = Files[1];
            Debug.WriteLine("Hello, world");
        }


        private LayoutAnchorableViewModel[] tools = {
            new FileStatsViewModel{ Title = "File Stats 1" },
            new FileStatsViewModel{ Title = "File Stats 2" }
        };


        public IEnumerable<LayoutAnchorableViewModel> Tools => tools;


        private FileViewModel activeDocument;

        public FileViewModel ActiveDocument
        {
            get => activeDocument;
            set
            {
                SetAndNotify(ref activeDocument, value);
            }
        }


        public void CreateNewFile()
        {
            Files.Add(new FileViewModel()
            {
                Title = "untitled"
            });
            ActiveDocument = Files.Last();
        }

    }
}
