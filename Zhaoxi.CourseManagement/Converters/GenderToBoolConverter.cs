using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Data;

namespace Zhaoxi.CourseManagement.Converters
{
    /// <summary>
    /// Gender to bool?
    /// 0: female, 1: male, 2: unknown
    /// </summary>
    public class GenderToBoolConverter : IValueConverter
    {
        // source --> bind target
        // actual type: value: System.Int32, parameter: System.String
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Debug.WriteLine($"Convert: {value.GetType()}, {parameter.GetType()}");
            if (value is int @int) // pattern match
            {
                if (int.TryParse(parameter as string, out int param))
                    return @int == param;
            }
            // true if the ToggleButton is checked; false if the ToggleButton is unchecked; otherwise null. The default is false.
            return null;
        }

        // bind target --> source
        // actual type: value System.Boolean, parameter: System.String
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Debug.WriteLine($"ConvertBack: {value}, {value.GetType()}, {parameter.GetType()}");
            if (value is bool @bool)
            {
                if (int.TryParse(parameter as string, out int param))
                    return @bool ? param : 1 - param;
            }
            return 2;
        }
    }
}
