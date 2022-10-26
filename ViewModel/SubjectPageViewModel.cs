using CommunityToolkit.Mvvm.ComponentModel;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;

[QueryProperty(nameof(Department), "Department")]
public partial class SubjectPageViewModel : BaseViewModel
{
	private readonly ICalendarApiService calendarApiService;

    [ObservableProperty]
    private Department department;

	public ObservableRangeCollection<Subject> Favourite { get; } = new();
    public ObservableRangeCollection<Subject> Harmonograms { get; } = new();

    public SubjectPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
		Favourite.Add(new Subject { Name = "Test", Shorthand = "TeS" });
        Favourite.Add(new Subject { Name = "Test2", Shorthand = "TeS2" });
        Favourite.Add(new Subject { Name = "Test2", Shorthand = "TeS2" });
        Favourite.Add(new Subject { Name = "Test2", Shorthand = "TeS2" });
        Harmonograms.Add(new Subject { Name = "Test2", Shorthand = "TeS2" });
        Harmonograms.Add(new Subject { Name = "Test2", Shorthand = "TeS2" });
        Harmonograms.Add(new Subject { Name = "Test2", Shorthand = "TeS2" });
        Harmonograms.Add(new Subject { Name = "Test2", Shorthand = "TeS2" });
        Harmonograms.Add(new Subject { Name = "Test2", Shorthand = "TeS2" });
    }
}
