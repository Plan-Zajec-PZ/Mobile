using MauiCalendarApp.ViewModel;

namespace MauiCalendarApp.View;

public partial class SessionPage : ContentPage
{
	public SessionPage(SessionPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}