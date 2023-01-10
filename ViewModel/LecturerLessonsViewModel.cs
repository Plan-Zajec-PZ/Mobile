using CommunityToolkit.Mvvm.ComponentModel;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;

[QueryProperty(nameof(Lecturer), "Data")]
public partial class LecturerLessonsViewModel : BaseViewModel
{
    private readonly ICalendarApiService calendarApiService;

    [ObservableProperty]
    private Lecturer lecturer;

    public ObservableRangeCollection<Lesson> Lessons { get; set; } = new();

    public ObservableRangeCollection<Legend> Legends { get; set; } = new();

    public LecturerLessonsViewModel(ICalendarApiService calendarApiService)
    {
        this.calendarApiService = calendarApiService;
    }

    public void LoadLessons()
    {
        var response = calendarApiService.GetLessonsForLecturer(Lecturer.Id);

        Lessons.AddRange(response.Schedule.Data.Lessons);
        Legends.AddRange(response.Schedule.Legends);
    }
}
