using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MauiCalendarApp.Model.Responses;

namespace MauiCalendarApp.ViewModel
{
    [QueryProperty(nameof(Faculties), "Data")]
    public partial class LecturersPageViewModel : BaseViewModel
    {
        private readonly ICalendarApiService calendarApiService;

        public List<Faculty> Faculties { get; set; }

        private List<FacultyRecturers> AllFacultyRecturers = new();

        [ObservableProperty]
        private List<FacultyRecturers> filteredFacultyRecturers = new();

        [ObservableProperty]
        private string searchPhrase;

        public LecturersPageViewModel(ICalendarApiService calendarApiService)
        {
            this.calendarApiService = calendarApiService;
        }

        public void LoadLeacturers()
        {
            foreach (var faculty in Faculties)
            {
                AllFacultyRecturers.Add(new FacultyRecturers
                {
                    Name = faculty.Name,
                    Lecturers = calendarApiService.GetLecturersForFaculty(faculty.Id)
                });
            }

            FilteredFacultyRecturers.AddRange(AllFacultyRecturers);
        }

        [RelayCommand]
        public void FilterLecturers()
        {

        }
    }
}
