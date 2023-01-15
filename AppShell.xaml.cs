using Clock_In_System_with_MAUI_and_SQLite.View;

namespace Clock_In_System_with_MAUI_and_SQLite;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AddUserView), typeof(AddUserView));
	}
}