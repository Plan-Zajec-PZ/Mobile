using MauiCalendarApp.ViewModel;

namespace MauiCalendarApp.View;

public partial class SessionPage : ContentPage
{
    private readonly SessionPageViewModel viewModel;

    public SessionPage(SessionPageViewModel viewModel)
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