using MauiCalendarApp.ViewModel;

namespace MauiCalendarApp.View;

public partial class MainPage : ContentPage
{
	private MainPageViewModel viewModel;

    public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		this.viewModel = viewModel;
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		viewModel.LoadDepartments();
	}
}
