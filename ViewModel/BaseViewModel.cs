using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Clock_In_System_with_MAUI_and_SQLite.ViewModel
{
	public partial class BaseViewModel : ObservableObject
	{
		public BaseViewModel()
		{
		}

		[ObservableProperty]
		[NotifyPropertyChangedFor(nameof(IsNotBusy))]
		bool isBusy;

		[ObservableProperty]
		string title;

		public bool IsNotBusy => !IsBusy;
	}
}