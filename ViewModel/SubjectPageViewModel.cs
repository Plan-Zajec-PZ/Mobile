using MauiCalendarApp.Interfaces;

namespace MauiCalendarApp.ViewModel;
public partial class SubjectPageViewModel : BaseViewModel
{
	private readonly ICalendarApiService calendarApiService;

	public SubjectPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
	}
}
