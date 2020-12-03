using Stylet;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Diagnostics;

namespace Fasetto.Word.ViewModels
{
    public class ShellViewModel : Screen
    {
        private const double NormalResizeBorderThickness = 5;

        public double ResizeBorderThickness { get; set; } = NormalResizeBorderThickness;

        public double CaptionHeight { get; private set; } = 42;
        public double CornerRadius { get; set; } = 10;
        public WindowState WindowState { get; set; } = WindowState.Normal;

        public double MinWidth { get; private set; } = 350;
        public double MinHeight { get; private set; } = 400;


        // FODY: On_PropertyName_Changed https://github.com/Fody/PropertyChanged/wiki/On_PropertyName_Changed
        private void OnWindowStateChanged()
        {
            Debug.WriteLine($"Window state => {WindowState}");
            if (WindowState == WindowState.Maximized)
                ResizeBorderThickness = 0;
            else
                ResizeBorderThickness = NormalResizeBorderThickness;

        }
    }
}
