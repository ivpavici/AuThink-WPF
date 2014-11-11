using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Authink.Desktop.Converters
{
    public class VisibilityBottunConvertor : IValueConverter 
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo language)
        {
            
            return value == null ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo language)
        {
            throw new NotImplementedException();
        }
    }
}
