using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WPFNotepad.Models;


namespace WPFNotepad.ViewModels
{
    public class FormatViewModel
    {
        public FormatModel Format { get; private set; } = new FormatModel();

        //public DocumentModel Document { get; private set; }

        //public FormatViewModel(DocumentModel document)
        //{
        //    Document = document;
        //    Format = new FormatModel();
        //}


        // WrapCommand
        public void ToggleWrap()
        {
            Format.Wrapping = Format.IsWrapped ? TextWrapping.NoWrap : TextWrapping.Wrap;

        }


    }
}
