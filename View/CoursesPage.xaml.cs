using MauiCalendarApp.ViewModel;

namespace MauiCalendarApp.View;

public partial class CoursesPage : ContentPage
{
    private readonly CoursesPageViewModel viewModel;

    public CoursesPage(CoursesPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        viewModel.CoursesPage = this;
        this.viewModel = viewModel;
        
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if(viewModel.AllCourses == null)
            viewModel.LoadCourses();
    }
}