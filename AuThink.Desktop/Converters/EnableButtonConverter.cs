using System.Globalization;
using System.Windows.Data;

namespace Authink.Desktop.Converters
{
    public class EnableButtonConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, CultureInfo language)
        {
            return value != null;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, CultureInfo language)
        {
            throw new System.NotImplementedException();
        }
    }
}
