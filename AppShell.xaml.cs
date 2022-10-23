using MauiCalendarApp.View;

namespace MauiCalendarApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(SubjectPage), typeof(SubjectPage));
	}
}
