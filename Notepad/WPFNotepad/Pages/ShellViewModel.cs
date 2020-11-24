using Stylet;
using WPFNotepad.ViewModels;
using WPFNotepad.Models;
using System.Diagnostics;
using System.Linq;
using System;

namespace WPFNotepad.Pages
{
    public class ShellViewModel : Screen
    {
        private DocumentModel document;
        private IWindowManager windowManager;

        public FormatViewModel Editor { get; set; }
        public FileViewModel File { get; set; }
        public HelpViewModel Help { get; set; }

        public ShellViewModel(IWindowManager windowManager)
        {
            this.windowManager = windowManager; // will be injected
            document = new DocumentModel();
            Editor = new FormatViewModel();
            File = new FileViewModel(document);
            Help = new HelpViewModel();
        }


        // Generate arbitrary strings for test purposes
        public void GenDummyText()
        {
            document.Text = RandomString(random.Next(10, 200));
        }


        // https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public void ShowFormatDialog()
        {
            windowManager.ShowDialog(Editor);
        }

        public void ToggleWrap()
        {

        }
    }
}
