using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Helpers;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MauiCalendarApp.View;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;
public partial class MainPageViewModel : BaseViewModel
{
	public ObservableRangeCollection<Faculty> Faculties { get; } = new();

	[ObservableProperty]
	private Faculty lecturers;

	private readonly ICalendarApiService calendarApiService;

	public MainPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
	}

	[RelayCommand]
	public void SelectDepartment(Faculty department)
	{
		Settings.LastSelectedDepartmentName = department.Name;

		Shell.Current.GoToAsync(nameof(CoursesPage), true, new Dictionary<string, object>
		{
			{
				"Data",
				department
			}
		});
	}

    [RelayCommand]
    public void FindLecturer()
	{
		if (Faculties.Count == 0)
			return;

		Shell.Current.GoToAsync(nameof(LecturersPage),true, new Dictionary<string, object>
		{
			{
				"Data",
				Faculties.ToList()
			}
		});
	}

	public void LoadDepartments()
	{
		var departments = calendarApiService.GetFaculties();

		string departmentName = Settings.LastSelectedDepartmentName;

        if (departmentName != null && departments.Count > 0)
		{
			var department = departments.Find(d => d.Name == departmentName);
			department.LastSelected = true;
        }

		var lastDepartment = departments.Last();
		Lecturers = lastDepartment;
		departments.Remove(lastDepartment);


        Faculties.Clear();
        Faculties.AddRange(departments);
    }
}
