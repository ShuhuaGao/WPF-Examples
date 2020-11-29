using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Data;
using System.IO;
using System.Diagnostics;

namespace TreeViews
{
    /// <summary>
    /// Given a path (either a folder or a file), convert it to an image path (pack URI)
    /// </summary>
    [ValueConversion(typeof(string), typeof(string))]
    class HeaderToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is string path))
                return null;
            // check whether the path is a file or a directory
            // https://stackoverflow.com/questions/439447/net-how-to-check-if-path-is-a-file-and-not-a-directory
            if (File.GetAttributes(path).HasFlag(FileAttributes.Directory))
            {
                // normal directory or a drive?
                if (new DirectoryInfo(path).Parent is null)
                    return "pack://siteoforigin:,,,/images/hardware.png";
                return "pack://siteoforigin:,,,/images/folder-closed.png";
            }
            Debug.WriteLine("---File");
            return "pack://siteoforigin:,,,/images/file.png";
        }

        // only one-way binding is intended. This method will not be called.
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
