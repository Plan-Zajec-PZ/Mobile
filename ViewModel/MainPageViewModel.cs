﻿using MauiCalendarApp.Interfaces;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;
public partial class MainPageViewModel : BaseViewModel
{
	public ObservableRangeCollection<string> Departments { get; } = new();

	private readonly ICalendarApiService calendarApiService;

	public MainPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;

		Departments.AddRange(calendarApiService.GetDepartments());
	}
}