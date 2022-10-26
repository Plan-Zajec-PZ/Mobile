using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Helpers;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;

[QueryProperty(nameof(Department), "Department")]
public partial class SubjectPageViewModel : BaseViewModel
{
	private readonly ICalendarApiService calendarApiService;

    public List<Subject> AllSubjects;

    [ObservableProperty]
    private Department department;

    [ObservableProperty]
    private string searchPhrase;

	public ObservableRangeCollection<Subject> Favourite { get; } = new();

    public ObservableRangeCollection<Subject> Harmonograms { get; } = new();

    public SubjectPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
    }

    public void LoadSubjects()
    {
        AllSubjects = calendarApiService.GetSubjects(Department.Id);

        Favourite.Clear();
        var favourites = Settings.FavouriteSubjects;
        Favourite.AddRange(favourites.Where(s => s.DepId == Department.Id));

        Harmonograms.Clear();
        var subjects = AllSubjects;
        subjects.RemoveAll(s => Favourite.Select(f => f.Id).Contains(s.Id));
        Harmonograms.AddRange(subjects);
    }

    [RelayCommand]
    public void FilterHarmonograms()
    {
        var filteredResult = AllSubjects.Where(s => s.Name.Contains(SearchPhrase) || s.Shorthand.Contains(SearchPhrase));
        Harmonograms.Clear();
        Harmonograms.AddRange(filteredResult);
    }

    [RelayCommand]
    public void AddToFavourite(Subject subject)
    {
        Favourite.Add(subject);
        var currentFavourite = Settings.FavouriteSubjects;
        currentFavourite.Add(subject);
        Settings.FavouriteSubjects = currentFavourite;
        Harmonograms.Remove(subject);
    }

    [RelayCommand]
    public void RemoveFromFavourite(Subject subject)
    {
        Favourite.Remove(subject);
        var currentFavourite = Settings.FavouriteSubjects;
        currentFavourite.RemoveAll(s => s.Id == subject.Id);
        Settings.FavouriteSubjects = currentFavourite;
        Harmonograms.Add(subject);
    }
}
