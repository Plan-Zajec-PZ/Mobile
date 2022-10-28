using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Helpers;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MauiCalendarApp.View;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;

[QueryProperty(nameof(Department), "Department")]
public partial class CoursesPageViewModel : BaseViewModel
{
	private readonly ICalendarApiService calendarApiService;

    public List<Course> AllCourses;

    [ObservableProperty]
    private Department department;

    [ObservableProperty]
    private string searchPhrase;

	public ObservableRangeCollection<Course> Favourite { get; } = new();

    public ObservableRangeCollection<Course> Courses { get; } = new();

    public CoursesPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
    }

    public void LoadCourses()
    {
        AllCourses = calendarApiService.GetSubjects(Department.Id);

        Favourite.Clear();
        var favourites = Settings.FavouriteSubjects;
        Favourite.AddRange(favourites.Where(s => s.DepId == Department.Id));

        Courses.Clear();
        var subjects = AllCourses;
        subjects.RemoveAll(s => Favourite.Select(f => f.Id).Contains(s.Id));
        Courses.AddRange(subjects);
    }

    [RelayCommand]
    public void FilterCourses()
    {
        var filteredResult = AllCourses.Where(s => s.Name.Contains(SearchPhrase) || s.Shorthand.Contains(SearchPhrase));
        Courses.Clear();
        Courses.AddRange(filteredResult);
    }

    [RelayCommand]
    public void AddToFavourite(Course subject)
    {
        Favourite.Add(subject);
        var currentFavourite = Settings.FavouriteSubjects;
        currentFavourite.Add(subject);
        Settings.FavouriteSubjects = currentFavourite;
        Courses.Remove(subject);
    }

    [RelayCommand]
    public void RemoveFromFavourite(Course subject)
    {
        Favourite.Remove(subject);
        var currentFavourite = Settings.FavouriteSubjects;
        currentFavourite.RemoveAll(s => s.Id == subject.Id);
        Settings.FavouriteSubjects = currentFavourite;
        Courses.Add(subject);
    }

    [RelayCommand]
    public void SelectCourse(Course course)
    {
        Shell.Current.GoToAsync(nameof(LessonsPage), true, new Dictionary<string, object>
        {
            {"Course", course }
        });
    }
}
