using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace WpfEnumConverterTest.Converter
{
	[ValueConversion(typeof(TicketType), typeof(bool))]
	public class TicketTypeStringToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is not TicketType sourceValue)
				return DependencyProperty.UnsetValue;

			// parameter shall be a TicketType value's string representation.
			return string.Equals(sourceValue.ToString(), (parameter as string), StringComparison.OrdinalIgnoreCase);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// If target value is false or invalid, UnsetValue will be returned.
			if (value is not true)
				return DependencyProperty.UnsetValue;

			var parameterValue = Enum.GetValues(typeof(TicketType)).Cast<TicketType>()
				.FirstOrDefault(x => string.Equals(x.ToString(), (parameter as string), StringComparison.OrdinalIgnoreCase));
			if (parameterValue is default(TicketType))
				return DependencyProperty.UnsetValue;

			return parameterValue;
		}
	}
}