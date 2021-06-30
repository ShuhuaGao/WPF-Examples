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
        // as the DockingManager.DocumentSource
        public ObservableCollection<FileViewModel> Files { get; set; } = new ObservableCollection<FileViewModel>();

        public ShellViewModel()
        {
            //Files.Add(new FileViewModel { Title = "file 1" });
            //Files.Add(new FileViewModel { Title = "file 2" });
            //Files.Add(new FileViewModel { Title = "file 3" });
            tools.Add(FileStats);
        }

        public FileStatsViewModel FileStats { get; private set; } = new() { Title = "File Stats" };



        private readonly List<LayoutAnchorableViewModel> tools = new();

        // as the DockingManager.AnchorablesSource
        public IEnumerable<LayoutAnchorableViewModel> Tools => tools;


        private FileViewModel activeDocument;

        public FileViewModel ActiveDocument
        {
            get => activeDocument;
            set
            {
                if (value != activeDocument)
                {
                    activeDocument = value;
                    FileStats.FilePath = activeDocument.FilePath;
                    NotifyOfPropertyChange();
                }
            }
        }


        public void CreateNewFile()
        {
            Files.Add(new FileViewModel { Title = "untitled" });
            ActiveDocument = Files.Last();
        }

        public void OpenFile(string filePath)
        {
            Files.Add(new FileViewModel(filePath));
            ActiveDocument = Files.Last();
        }

    }
}
