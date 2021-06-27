using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using EdiAvalon.ViewModels.ADBase;

namespace EdiAvalon.ViewModels
{
    /// <summary>
    /// Representing a file.
    /// </summary>
    public class FileViewModel : LayoutDocumentViewModel
    {
        public FileViewModel(string filePath)
        {
            try
            {
                Title = Path.GetFileName(filePath);
                FilePath = filePath;
                TextContent = File.ReadAllText(filePath);
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Create an empty file.
        /// </summary>
        public FileViewModel()
        {
            Title = "Untitled";
            TextContent = "This is an empty file...";
        }

        private string filePath;

        public string FilePath
        {
            get => filePath;
            set
            {
                SetAndNotify(ref filePath, value);
                ContentId = filePath;
            }
        }


        private string textContent;

        public string TextContent
        {
            get => textContent;
            set => SetAndNotify(ref textContent, value);
        }



    }
}
