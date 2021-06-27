using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Stylet;
using EdiAvalon.ViewModels;

namespace EdiAvalon.ViewModels
{
    public class ShellViewModel : Screen
    {
        public ObservableCollection<FileViewModel> Files { get; set; }

        public FileViewModel OneFile { get; } = new FileViewModel();

    }
}
