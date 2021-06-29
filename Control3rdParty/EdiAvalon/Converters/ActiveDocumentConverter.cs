using System;
using System.Collections.Generic;
using System.Diagnostics;
using EdiAvalon.ViewModels;
using System.Windows.Data;

namespace EdiAvalon.Converters
{
    public class ActiveDocumentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is FileViewModel)
            {
                //Debug.WriteLine(">> Convert from FileViewModel");
                return value;
            }
            // Used as a returned value to instruct the binding engine not to perform any action.
            return Binding.DoNothing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // only if the active content is a `FileViewModel` will we update the `ActiveDocument`
            if (value is FileViewModel)
                return value;

            return Binding.DoNothing;
        }
    }
}
