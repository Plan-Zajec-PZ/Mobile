using MauiCalendarApp.ViewModel;

namespace MauiCalendarApp.View;

public partial class SubjectPage : ContentPage
{
    private readonly SubjectPageViewModel viewModel;

    public SubjectPage(SubjectPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
        this.viewModel = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.LoadSubjects();
    }
}