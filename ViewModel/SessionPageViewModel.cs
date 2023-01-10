using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Model;
using MauiCalendarApp.Model.Requests;
using MauiCalendarApp.Model.Responses;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel;

[QueryProperty(nameof(LessonsResponse), "Data")]
public partial class SessionPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private LessonsResponse lessonsResponse;

    public ObservableRangeCollection<Shedule> FilteredLessons { get; set; }

    [ObservableProperty]
    private List<string> groups;

    [ObservableProperty]
    private int groupIndex;

    [ObservableProperty]
    private List<Legend> legends;
    private List<Group> AllGroups;


    public SessionPageViewModel()
    {
        FilteredLessons = new();
    }

    public Task LoadLessons()
    {
        if (AllGroups is null)
        {
            AllGroups = LessonsResponse.Groups;

            Groups = AllGroups.Select(l => l.Name).ToList();
            GroupIndex = 0;

            FilterLessons();

            Legends = LessonsResponse.Legends;
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    public void FilterLessons()
    {
        FilteredLessons.Clear();
        FilteredLessons.AddRange(AllGroups
            .FirstOrDefault(g => g.Name == Groups[GroupIndex]).ShedulePlan
            );
    }

}
