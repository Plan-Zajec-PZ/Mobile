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

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        viewModel.ChangeCurrentGroup((string)picker.SelectedItem);
    }
}