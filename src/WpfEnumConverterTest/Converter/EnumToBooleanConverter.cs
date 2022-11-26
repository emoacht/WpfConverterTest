using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WpfEnumConverterTest.Converter
{
	[ValueConversion(typeof(Enum), typeof(bool))]
	public class EnumToBooleanConverter : IValueConverter
	{
		public Type? SourceType { get; set; }

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			// If SourceType is set, the invocation of GetType method will not be necessary.
			var sourceType = SourceType ?? value?.GetType();

			var parameterValue = GetParameterValue(sourceType, parameter);
			if (parameterValue is null)
				return DependencyProperty.UnsetValue;

			return Enum.Equals(value, parameterValue);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var sourceType = SourceType ?? targetType;

			var parameterValue = GetParameterValue(sourceType, parameter);
			if (parameterValue is null)
				return DependencyProperty.UnsetValue;

			if (value is true)
				return parameterValue;

			// If target value is false, the default value will be returned.
			// This will cause IndexOutOfRangeException in case the enum type has no value.
			return Enum.GetValues(sourceType).GetValue(0)!;
		}

		private static object? GetParameterValue(Type? sourceType, object? parameter)
		{
			if (sourceType?.IsEnum is true)
			{
				if (sourceType == parameter?.GetType())
					return parameter;

				if (Enum.TryParse(sourceType, (parameter as string), true, out object? parameterValue))
					return parameterValue;
			}
			return null;
		}
	}
}