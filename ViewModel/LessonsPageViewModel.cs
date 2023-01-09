using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MauiCalendarApp.View;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;

[QueryProperty(nameof(Course), "Course")]
public partial class LessonsPageViewModel : BaseViewModel
{
	private readonly ICalendarApiService calendarApiService;

    [ObservableProperty]
    private Course course;
    [ObservableProperty]
    private int groupIndex;
    [ObservableProperty]
    private string week;
    public ObservableRangeCollection<DayLesson> LessonsForGroup { get; set; }
    [ObservableProperty]
    private List<string> groups;
    [ObservableProperty]
    private List<string> weeks = new() { "1", "2"};
    [ObservableProperty]
    private List<Legend> legends;
    private List<Group> AllLessons;

    public LessonsPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
        LessonsForGroup = new();
    }

	public Task LoadLessons()
    {
        if (AllLessons is null)
        {
            AllLessons = calendarApiService.GetLessons();
            Weeks = calendarApiService.GetWeeks();
            Groups = AllLessons.Select(l => l.Name).ToList();
            GroupIndex = 0;
            LessonsForGroup.AddRange(AllLessons.FirstOrDefault(g => g.Name == Groups[GroupIndex]).LessonPlans);
            Legends = calendarApiService.GetLegends();
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    public async void GoToSession()
    {
        await Shell.Current.GoToAsync(nameof(SessionPage));
    }

    [RelayCommand]
    public void ChangeCurrentGroup()
    {
        LessonsForGroup.Clear();
        LessonsForGroup.AddRange(AllLessons.FirstOrDefault(g => g.Name == Groups[GroupIndex]).LessonPlans);
    }

    public void SelectWeek(string week)
    {
        Week = week;
    }
}
