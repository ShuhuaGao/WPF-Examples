using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Stylet;
using EdiAvalon.ViewModels;
using EdiAvalon.ViewModels.ADBase;

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
        }


        private LayoutAnchorableViewModel[] tools = {
            new FileStatsViewModel{ Title = "File Stats 1" },
            new FileStatsViewModel{ Title = "File Stats 2" }
        };

        // serve as the 
        public IEnumerable<LayoutAnchorableViewModel> Tools => tools;


    }
}
