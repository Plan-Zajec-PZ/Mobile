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
        AllCourses = calendarApiService.GetCourses(Department.Id);

        Favourite.Clear();
        var favourites = Settings.FavouriteCoursesId;
        Favourite.AddRange(AllCourses.Where(c => favourites.Contains(c.Id)));

        Courses.Clear();
        var subjects = AllCourses;
        subjects.RemoveAll(s => Favourite.Select(f => f.Id).Contains(s.Id));
        Courses.AddRange(subjects);
    }

    [RelayCommand]
    public async Task FilterCourses()
    {
        var filteredResult = AllCourses;

        if(!string.IsNullOrWhiteSpace(searchPhrase))
            filteredResult = AllCourses.Where(s =>
        s.Name.ToLower().Contains(SearchPhrase.ToLower()) || s.Shorthand.ToLower().Contains(SearchPhrase.ToLower())).ToList();

        Courses.Clear();
        Courses.AddRange(filteredResult);
    }

    [RelayCommand]
    public async Task AddToFavourite(Course subject)
    {
        Favourite.Add(subject);
        Courses.Remove(AllCourses.First(c => c.Id == subject.Id));

        var currentFavourite = Settings.FavouriteCoursesId;
        currentFavourite.Add(subject.Id);
        Settings.FavouriteCoursesId = currentFavourite;
    }

    [RelayCommand]
    public async Task RemoveFromFavourite(Course subject)
    {
        Favourite.Remove(subject);
        Courses.Add(subject);

        var currentFavourite = Settings.FavouriteCoursesId;
        currentFavourite.RemoveAll(s => s == subject.Id);
        Settings.FavouriteCoursesId = currentFavourite;
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
