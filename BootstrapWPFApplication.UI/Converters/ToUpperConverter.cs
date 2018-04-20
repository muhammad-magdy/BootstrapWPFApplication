using System;
using System.Globalization;
using System.Windows.Data;

namespace BootstrapWPFApplication.UI.Converters
{
    /// <summary>
    /// Converts string values to upper case.
    /// </summary>
    public class ToUpperConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                var strValue = value.ToString();
                return strValue.ToUpperInvariant();
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
