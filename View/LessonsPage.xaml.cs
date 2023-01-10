using MauiCalendarApp.ViewModel;

namespace MauiCalendarApp.View;

public partial class LessonsPage : ContentPage
{
    private readonly LessonsPageViewModel viewModel;

    public LessonsPage(LessonsPageViewModel viewModel)
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