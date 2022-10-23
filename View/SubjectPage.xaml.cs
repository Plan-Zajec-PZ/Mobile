using MauiCalendarApp.ViewModel;

namespace MauiCalendarApp.View;

public partial class SubjectPage : ContentPage
{
	public SubjectPage(SubjectPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}