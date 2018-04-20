using System;
using System.Globalization;
using System.Windows.Data;

namespace BootstrapWPFApplication.UI.Converters
{
    public class EmptyStringToValueConverter : BaseConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            return string.IsNullOrEmpty(value.ToString()) ? parameter : value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
