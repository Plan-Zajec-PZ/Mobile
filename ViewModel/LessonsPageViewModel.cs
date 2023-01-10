using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MauiCalendarApp.Model.Requests;
using MauiCalendarApp.Model.Responses;
using MauiCalendarApp.View;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;

[QueryProperty(nameof(LessonsRequest), "Data")]
public partial class LessonsPageViewModel : BaseViewModel
{
	private readonly ICalendarApiService calendarApiService;
    public LessonsRequest LessonsRequest { get; set; }

    [ObservableProperty]
    private string courseName;
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
    private LessonsResponse LessonsResponse;

    public LessonsPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
        FilteredLessons = new();
    }

	public Task LoadLessons()
    {
        if (AllGroups is null)
        {
            LessonsResponse = calendarApiService.GetLessons(LessonsRequest);
            CourseName = LessonsResponse.Name;
            AllGroups = LessonsResponse.Groups;

            Groups = AllGroups.Select(l => l.Name).ToList();
            GroupIndex = 0;

            Weeks = LessonsResponse.Groups[GroupIndex].Weeks;
            WeekIndex = 0;

            FilterLessons();

            Legends = LessonsResponse.Legends;
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    public async void GoToSession()
    {
        await Shell.Current.GoToAsync(nameof(SessionPage), true, new Dictionary<string, object>
        {
            {
                "Data",
                LessonsResponse
            }
        });
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
