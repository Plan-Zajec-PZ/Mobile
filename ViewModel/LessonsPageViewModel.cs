using CommunityToolkit.Mvvm.ComponentModel;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;

namespace MauiCalendarApp.ViewModel;

[QueryProperty(nameof(Course), "Course")]
public partial class LessonsPageViewModel : BaseViewModel
{
	private readonly ICalendarApiService calendarApiService;

    [ObservableProperty]
    private Course course;

    public List<Group> AllLessons;

    public LessonsPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
	}

	public void LoadLessons()
	{
		AllLessons = calendarApiService.GetLessons();
	}
}
