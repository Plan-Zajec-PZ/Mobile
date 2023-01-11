using MauiCalendarApp.ViewModel;

namespace MauiCalendarApp.View;

public partial class LecturerLessonsPage : ContentPage
{
	private readonly LecturerLessonsViewModel viewModel;

	public LecturerLessonsPage(LecturerLessonsViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.LoadLessons();
    }
}