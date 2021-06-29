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
            //Files.Add(new FileViewModel { Title = "file 1" });
            //Files.Add(new FileViewModel { Title = "file 2" });
            //Files.Add(new FileViewModel { Title = "file 3" });
            tools.Add(fileStats);
        }

        private readonly FileStatsViewModel fileStats = new() { Title = "File Stats" };

        private List<LayoutAnchorableViewModel> tools = new();


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
                    fileStats.FilePath = activeDocument.FilePath;
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
