using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Stylet;
using EdiAvalon.ViewModels;

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

    }
}
