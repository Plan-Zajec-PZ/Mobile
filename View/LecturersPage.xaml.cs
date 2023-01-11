using MauiCalendarApp.ViewModel;

namespace MauiCalendarApp.View;

public partial class LecturersPage : ContentPage
{
    private readonly LecturersPageViewModel viewModel;

    public LecturersPage(LecturersPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.LoadLeacturers();
    }
}