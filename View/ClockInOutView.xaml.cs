using Clock_In_System_with_MAUI_and_SQLite.ViewModel;

namespace Clock_In_System_with_MAUI_and_SQLite.View;

public partial class ClockInOutView : ContentPage
{
	public ClockInOutView(ClockInOutViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
