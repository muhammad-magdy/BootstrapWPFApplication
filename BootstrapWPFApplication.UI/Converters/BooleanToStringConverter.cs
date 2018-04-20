using System;
using System.Windows.Data;

namespace BootstrapWPFApplication.UI.Converters
{
    public class BooleanToStringConverter : BaseConverter, IValueConverter
    {
        public string TrueValue { get; set; }
        public string FalseValue { get; set; }

        public BooleanToStringConverter()
        {
            TrueValue = "True";
            FalseValue = "False";
        }
        public BooleanToStringConverter(string trueValue, string falseValue)
        {
            TrueValue = trueValue;
            FalseValue = falseValue;
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool flag = false;
            if (value is bool)
            {
                flag = (bool)value;
            }
            else if (value is bool?)
            {
                bool? nullable = (bool?)value;
                flag = nullable.HasValue ? nullable.Value : false;
            }

            bool inverse = (parameter as string) == "inverse";

            if (inverse)
            {
                return (flag ? FalseValue : TrueValue);
            }
            else
            {
                return (flag ? TrueValue : FalseValue);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return null;
            }
            bool inverse = (parameter as string) == "inverse";
            if (inverse)
            {
                return string.Equals(value.ToString(), FalseValue, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                return string.Equals(value.ToString(), TrueValue, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
