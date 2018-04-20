using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace BootstrapWPFApplication.UI.Converters
{
    public class StringMatchToVisibilityConverter : BaseConverter, IValueConverter
    {
        public string MatchValue { get; set; }

        public StringMatchToVisibilityConverter(string matchValue)
        {
            MatchValue = matchValue;
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool flag = false;
            if (value is string)
            {
                flag = string.Equals(value.ToString(), MatchValue, StringComparison.OrdinalIgnoreCase);
            }
            var inverse = (parameter as string) == "inverse";

            if (inverse)
            {
                return (flag ? Visibility.Collapsed : Visibility.Visible);
            }
            else
            {
                return (flag ? Visibility.Visible : Visibility.Collapsed);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
