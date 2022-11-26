using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfEnumConverterTest
{
	public class MainWindowViewModel : ObservableObject
	{
		public TicketType Ticket1
		{
			get => GetProperty();
			set => SetProperty(value);
		}

		public TicketType Ticket2
		{
			get => GetProperty();
			set => SetProperty(value);
		}

		public TicketType Ticket3
		{
			get => GetProperty();
			set => SetProperty(value);
		}

		public TicketType Ticket4
		{
			get => GetProperty();
			set => SetProperty(value);
		}

		public TicketType Ticket5
		{
			get => GetProperty();
			set => SetProperty(value);
		}

		public TicketType Ticket6
		{
			get => GetProperty();
			set => SetProperty(value);
		}

		public TicketType Ticket7
		{
			get => GetProperty();
			set => SetProperty(value);
		}

		public TicketType Ticket8
		{
			get => GetProperty();
			set => SetProperty(value);
		}

		public TicketType Ticket9
		{
			get => GetProperty();
			set => SetProperty(value);
		}

		public TicketType Ticket10
		{
			get => GetProperty();
			set => SetProperty(value);
		}

		private readonly Dictionary<string, TicketType> _values = new();

		private TicketType GetProperty([CallerMemberName] string? propertyName = null)
		{
			return _values.TryGetValue(propertyName!, out TicketType value) ? value : default;
		}

		private bool SetProperty(TicketType newValue, [CallerMemberName] string? propertyName = null)
		{
			var oldValue = GetProperty(propertyName);
			if (oldValue == newValue)
				return false;

			_values[propertyName!] = newValue;
			OnPropertyChanged(propertyName);
			Debug.WriteLine($"{propertyName} -> {newValue}");
			return true;
		}
	}
}