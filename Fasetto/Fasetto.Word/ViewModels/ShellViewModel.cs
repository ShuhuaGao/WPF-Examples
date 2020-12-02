using System;
using System.Collections.Generic;
using System.Text;

namespace Fasetto.Word.ViewModels
{
    class ShellViewModel
    {
        public double ResizeBorderThickness { get; set; } = 5;
        public double CaptionHeight { get; private set; } = 42;
        public double CornerRadius { get; set; } = 10;
    }
}
