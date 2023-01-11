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

    public ObservableRangeCollection<LecturerSheduleContent> Shedules { get; set; } = new();

    public ObservableRangeCollection<Legend> Legends { get; set; } = new();

    public LecturerLessonsViewModel(ICalendarApiService calendarApiService)
    {
        this.calendarApiService = calendarApiService;
    }

    public void LoadLessons()
    {
        var response = calendarApiService.GetLessonsForLecturer(Lecturer.Id);

        Shedules.AddRange(response.Schedule.Data);
        Legends.AddRange(response.Schedule.Legends);
    }
}
