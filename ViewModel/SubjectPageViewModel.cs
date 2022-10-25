using CommunityToolkit.Mvvm.ComponentModel;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;

namespace MauiCalendarApp.ViewModel;

[QueryProperty(nameof(Department), "Department")]
public partial class SubjectPageViewModel : BaseViewModel
{
	private readonly ICalendarApiService calendarApiService;

    [ObservableProperty]
    private Department department;

    public SubjectPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
	}
}
