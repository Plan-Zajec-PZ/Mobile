﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MauiCalendarApp.View;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;

[QueryProperty(nameof(Course), "Course")]
public partial class LessonsPageViewModel : BaseViewModel
{
	private readonly ICalendarApiService calendarApiService;

    [ObservableProperty]
    private Course course;
    [ObservableProperty]
    private string group;
	public ObservableRangeCollection<DayLesson> LessonsForGroup { get; set; }
    [ObservableProperty]
    private List<string> groups;
    [ObservableProperty]
    private List<Legend> legends;
    private List<Group> AllLessons;

    public LessonsPageViewModel(ICalendarApiService calendarApiService)
	{
		this.calendarApiService = calendarApiService;
        LessonsForGroup = new();

    }

	public async Task LoadLessons()
	{
		if (AllLessons is null)
        {
            AllLessons = calendarApiService.GetLessons();
            Groups = AllLessons.Select(l => l.Name).ToList();
            Group = Groups.First();
            LessonsForGroup.AddRange(AllLessons.FirstOrDefault(g => g.Name == Group).LessonPlans);
            Legends = calendarApiService.GetLegends();
        }
    }

    [RelayCommand]
    public async void GoToSession()
    {
        await Shell.Current.GoToAsync(nameof(SessionPage));
    }

    [RelayCommand]
    public void ChangeCurrentGroup(string group)
    {
        LessonsForGroup.Clear();
        LessonsForGroup.AddRange(AllLessons.FirstOrDefault(g => g.Name == Group).LessonPlans);
    }
}
