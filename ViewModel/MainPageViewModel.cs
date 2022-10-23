using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;
public partial class MainPageViewModel : BaseViewModel
{
	public ObservableRangeCollection<Department> Departments { get; } = new();

	private readonly ICalendarApiService calendarApiService;

	public MainPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;

		Departments.AddRange(calendarApiService.GetDepartments());
	}

	[RelayCommand]
	public void SelectDepartment(Department department)
	{
		Departments.First(d => d.Name == department.Name).LastSelected = true;
	}
}
