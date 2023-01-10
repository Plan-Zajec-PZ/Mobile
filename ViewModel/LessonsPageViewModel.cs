using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MauiCalendarApp.Model.Requests;
using MauiCalendarApp.View;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;

[QueryProperty(nameof(LessonsRequest), "Data")]
public partial class LessonsPageViewModel : BaseViewModel
{
	private readonly ICalendarApiService calendarApiService;
    public LessonsRequest LessonsRequest { get; set; }

    [ObservableProperty]
    private Course course;
    [ObservableProperty]
    private int groupIndex;
    [ObservableProperty]
    private int weekIndex;
    public ObservableRangeCollection<Shedule> FilteredLessons { get; set; }
    [ObservableProperty]
    private List<string> groups;
    [ObservableProperty]
    private List<string> weeks = new() { "1", "2"};
    [ObservableProperty]
    private List<Legend> legends;
    private List<Group> AllGroups;

    public LessonsPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
        FilteredLessons = new();
    }

	public Task LoadLessons()
    {
        if (AllGroups is null)
        {
            var response = calendarApiService.GetLessons(LessonsRequest);
            AllGroups = response.Groups;

            Groups = AllGroups.Select(l => l.Name).ToList();
            GroupIndex = 0;

            Weeks = response.Groups[GroupIndex].Weeks;
            WeekIndex = 0;

            FilterLessons();

            Legends = response.Legends;
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    public async void GoToSession()
    {
        await Shell.Current.GoToAsync(nameof(SessionPage));
    }

    [RelayCommand]
    public void FilterLessons()
    {
        FilteredLessons.Clear();
        FilteredLessons.AddRange(AllGroups
            .FirstOrDefault(g => g.Name == Groups[GroupIndex]).ShedulePlan
            .Where(l => l.WeekOfYear == Weeks[weekIndex])
            );
    }
}
