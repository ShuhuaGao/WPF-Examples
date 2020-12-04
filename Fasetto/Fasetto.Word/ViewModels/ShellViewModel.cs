using Stylet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Fasetto.Word.ViewModels
{
    public class ShellViewModel : Screen
    {
        private const double NormalResizeBorderThickness = 5;

        public double ResizeBorderThickness { get; set; } = NormalResizeBorderThickness;

        public double CaptionHeight { get; private set; } = 40;
        public double CornerRadius { get; set; } = 10;

        public double MinWidth { get; private set; } = 350;
        public double MinHeight { get; private set; } = 400;






    }
}
