using System;
using System.Collections.Generic;
using System.Text;

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
            }
        }


        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { OnPropertyChanged(ref filePath, value); }
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { OnPropertyChanged(ref fileName, value); }
        }

        public bool IsEmpty => string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath);

    }
}
