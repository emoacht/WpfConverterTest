using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfEnumConverterTest.Converter
{
	[ValueConversion(typeof(TicketType), typeof(bool))]
	public class TicketTypeToBooleanConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value is not TicketType sourceValue)
				return DependencyProperty.UnsetValue;

			// parameter may be a TicketType value or a TicketType value's string representation.
			if ((parameter is not TicketType parameterValue) &&
				!Enum.TryParse((parameter as string), true, out parameterValue))
				return DependencyProperty.UnsetValue;

			return (sourceValue == parameterValue);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// If target value is invalid, UnsetValue will be returned.
			if (value is not bool targetValue)
				return DependencyProperty.UnsetValue;

			if ((parameter is not TicketType parameterValue) &&
				!Enum.TryParse((parameter as string), true, out parameterValue))
				return DependencyProperty.UnsetValue;

			// If target value is false, the default value will be returned.
			return targetValue ? parameterValue : default(TicketType);
		}
	}
}