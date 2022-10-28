using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Helpers;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MauiCalendarApp.View;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;
public partial class MainPageViewModel : BaseViewModel
{
	public ObservableRangeCollection<Department> Departments { get; } = new();

	private readonly ICalendarApiService calendarApiService;

	public MainPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
	}

	[RelayCommand]
	public void SelectDepartment(Department department)
	{
		Settings.LastSelectedDepartmentName = department.Name;

		Shell.Current.GoToAsync(nameof(CoursesPage), true, new Dictionary<string, object>
		{
			{"Department", department }
		});
	}

	public void LoadDepartments()
	{
		var departments = calendarApiService.GetDepartments();
		string departmentName = Settings.LastSelectedDepartmentName;


        if (departmentName != null)
		{
			var department = departments.Find(d => d.Name == departmentName);
			department.LastSelected = true;
        }	

		Departments.Clear();
        Departments.AddRange(departments);
    }
}
