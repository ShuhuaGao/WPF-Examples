using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using WPFNotepad.Models;


namespace WPFNotepad.ViewModels
{
    public class EditorViewModel
    {
        public FormatModel Format { get; set; }

        public DocumentModel Document { get; private set; }

        public EditorViewModel(DocumentModel document)
        {
            Document = document;
            Format = new FormatModel();
        }

        // FormatCommand 
        public void OpenStyleDialog()
        {

            throw new NotImplementedException();
        }

        // WrapCommand
        public void ToggleWrap()
        {
            Format.Wrapping = Format.IsWrapped ? TextWrapping.NoWrap : TextWrapping.Wrap;

        }


    }
}
