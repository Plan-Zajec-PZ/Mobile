﻿using MauiCalendarApp.View;

namespace MauiCalendarApp;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CoursesPage), typeof(CoursesPage));
        Routing.RegisterRoute(nameof(LessonsPage), typeof(LessonsPage));
        Routing.RegisterRoute(nameof(SessionPage), typeof(SessionPage));
        Routing.RegisterRoute(nameof(LecturersPage), typeof(LecturersPage));
        Routing.RegisterRoute(nameof(LecturerLessonsPage), typeof(LecturerLessonsPage));
    }
}
