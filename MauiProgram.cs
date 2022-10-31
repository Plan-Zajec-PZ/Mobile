using CommunityToolkit.Maui;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Services;
using MauiCalendarApp.View;
using MauiCalendarApp.ViewModel;

namespace MauiCalendarApp;

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
			})
			.UseMauiCommunityToolkit();

		builder.Services.AddSingleton<ICalendarApiService, CalendarApiService>();

        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<MainPage>();

        builder.Services.AddTransient<CoursesPageViewModel>();
        builder.Services.AddTransient<CoursesPage>();

        builder.Services.AddTransient<LessonsPageViewModel>();
        builder.Services.AddTransient<LessonsPage>();

        builder.Services.AddTransient<SessionPageViewModel>();
        builder.Services.AddTransient<SessionPage>();

        return builder.Build();
	}
}
