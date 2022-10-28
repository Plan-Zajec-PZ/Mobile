using MauiCalendarApp.ViewModel;

namespace MauiCalendarApp.View;

public partial class CoursesPage : ContentPage
{
    private readonly CoursesPageViewModel viewModel;

    public CoursesPage(CoursesPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.LoadCourses();
    }
}