using Microsoft.Extensions.Logging;
using Clock_In_System_with_MAUI_and_SQLite.View;
using Clock_In_System_with_MAUI_and_SQLite.ViewModel;
using Clock_In_System_with_MAUI_and_SQLite.Service;

namespace Clock_In_System_with_MAUI_and_SQLite;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
		// Views
		builder.Services.AddTransient<AddUserView>();
		builder.Services.AddSingleton<ClockInOutView>();

		// ViewModels
		builder.Services.AddTransient<AddUserViewModel>();
		builder.Services.AddSingleton<ClockInOutViewModel>();

		// Services
		builder.Services.AddSingleton<UserService>();
		builder.Services.AddSingleton<ClockEntryService>();

		return builder.Build();
	}
}

