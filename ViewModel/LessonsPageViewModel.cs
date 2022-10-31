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
    private string group;
	[ObservableProperty]
	private List<DayLesson> lessonsForGroup = new();
    [ObservableProperty]
    private List<string> groups;
    public List<Group> AllLessons;

    public LessonsPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
	}

	public async void LoadLessons()
	{
		AllLessons = calendarApiService.GetLessons();
		Groups = AllLessons.Select(l => l.Name).ToList();
        Group = Groups.First();
        LessonsForGroup = AllLessons.FirstOrDefault(g => g.Name == Group).LessonPlans;
    }

    [RelayCommand]
    public async void GoToSession()
    {
        await Shell.Current.GoToAsync(nameof(SessionPage));
    }

    [RelayCommand]
    public async void ChangeCurrentGroup(string group)
    {
        LessonsForGroup.Clear();
        LessonsForGroup = AllLessons.FirstOrDefault(g => g.Name == Group).LessonPlans;
    }
}
