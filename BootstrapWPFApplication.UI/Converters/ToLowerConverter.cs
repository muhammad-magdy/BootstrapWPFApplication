using System;
using System.Globalization;
using System.Windows.Data;

namespace BootstrapWPFApplication.UI.Converters
{
    /// <summary>
    /// Converts string values to lower case.
    /// </summary>
    public class ToLowerConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var strValue = value.ToString();
                return strValue.ToLowerInvariant();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
