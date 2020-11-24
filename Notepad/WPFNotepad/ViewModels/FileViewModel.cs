using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Diagnostics;
using WPFNotepad.Models;

namespace WPFNotepad.ViewModels
{
    public class FileViewModel
    {
        public DocumentModel Document { get; set; }

        public FileViewModel(DocumentModel document)
        {
            Document = document;
        }

        public void NewFile()
        {
            Document.FileName = "Untitled";
            Document.FilePath = string.Empty;
            Document.Text = string.Empty;
            Debug.WriteLine("----- New file");
        }

        public void SaveFile()
        {
            File.WriteAllText(Document.FilePath, Document.Text);
        }

        public void SaveFileAs()
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "Text File (*.txt)|*.txt";
            if (sfd.ShowDialog() == true)
            {
                DockFile(sfd);
                SaveFile();
            }
        }

        public void OpenFile()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Text File (*.txt)|*.txt";
            if (ofd.ShowDialog() == true)
            {
                var fileName = ofd.FileName; // containing the full path of the file selected
                Document.Text = File.ReadAllText(fileName);
                DockFile(ofd);
            }
        }


        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.FilePath = dialog.FileName;
            Document.FileName = dialog.SafeFileName;
            Debug.WriteLine($"Dock: {Document.FilePath}, {Document.FileName}");
        }
    }
}
