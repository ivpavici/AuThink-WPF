using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Authink.Desktop.Converters
{
    public class MultiplyByScreenRatio : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo language)
        {
            if(!(value is double)) { throw new ArgumentException("Expected double", "value"); }

            return (double)value * Double.Parse(Window.ActualHeightProperty.ToString()) / Double.Parse(Window.ActualWidthProperty.ToString()) ;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo language)
        {
            throw new System.NotSupportedException();
        }
    }
}
