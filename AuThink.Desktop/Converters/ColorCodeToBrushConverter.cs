using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace AuThink.Desktop.Converters
{
	public class ColorCodeToBrushConverter: IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var colorCode = value as string;
			if (string.IsNullOrEmpty(colorCode))
				return DependencyProperty.UnsetValue;

			return (SolidColorBrush)(new BrushConverter().ConvertFrom(colorCode));
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
