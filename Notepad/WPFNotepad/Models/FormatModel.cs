using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Text;

namespace WPFNotepad.Models
{
    public class FormatModel : ObservableObject
    {
        private FontStyle style;

        public FontStyle Style
        {
            get { return style; }
            set { OnPropertyChanged(ref style, value); }
        }


        private FontWeight weight;

        public FontWeight Weight
        {
            get { return weight; }
            set { OnPropertyChanged(ref weight, value); }
        }


        private FontFamily family;

        public FontFamily Family
        {
            get { return family; }
            set { OnPropertyChanged(ref family, value); }
        }


        private TextWrapping wrapping;

        public TextWrapping Wrapping
        {
            get { return wrapping; }
            set
            {
                OnPropertyChanged(ref wrapping, value);
                IsWrapped = !(wrapping == TextWrapping.NoWrap);
            }
        }


        private bool isWrapped;

        public bool IsWrapped
        {
            get { return isWrapped; }
            set { OnPropertyChanged(ref isWrapped, value); }
        }




    }
}
