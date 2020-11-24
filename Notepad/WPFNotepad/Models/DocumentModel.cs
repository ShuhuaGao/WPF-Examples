using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace WPFNotepad.Models
{
    public class DocumentModel : ObservableObject
    {
        private string text;

        public string Text
        {
            get { return text; }
            set
            {
                // set and notify
                OnPropertyChanged(ref text, value);
                //Debug.WriteLine($"Text: {value}");
            }
        }


        private string filePath = "Empty path";

        public string FilePath
        {
            get { return filePath; }
            set { OnPropertyChanged(ref filePath, value); }
        }

        private string fileName = "Untitled";

        public string FileName
        {
            get { return fileName; }
            set { OnPropertyChanged(ref fileName, value); }
        }

        public bool IsEmpty => string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath);

        public DocumentModel()
        {
            Text = "Some test text";
        }

    }
}
