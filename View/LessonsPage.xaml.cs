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

    private void GroupChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        viewModel.ChangeCurrentGroup((string)picker.SelectedItem);
    }

    private void WeekChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        viewModel.SelectWeek((string)picker.SelectedItem);
    }
}