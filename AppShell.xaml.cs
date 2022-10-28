using MauiCalendarApp.View;

namespace MauiCalendarApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CoursesPage), typeof(CoursesPage));
        Routing.RegisterRoute(nameof(LessonsPage), typeof(LessonsPage));
    }
}
