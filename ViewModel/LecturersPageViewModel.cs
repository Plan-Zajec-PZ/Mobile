using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MauiCalendarApp.Model.Responses;
using MvvmHelpers;

namespace MauiCalendarApp.ViewModel
{
    [QueryProperty(nameof(Faculties), "Data")]
    public partial class LecturersPageViewModel : BaseViewModel
    {
        private readonly ICalendarApiService calendarApiService;

        public List<Faculty> Faculties { get; set; }

        private List<FacultyRecturers> AllFacultyRecturers = new();

        public ObservableRangeCollection<FacultyRecturers> FilteredFacultyRecturers { get; } = new();

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
            FilteredFacultyRecturers.Clear();
            FilteredFacultyRecturers.AddRange(AllFacultyRecturers);
        }

        [RelayCommand]
        public void FilterLecturers()
        {
            if (string.IsNullOrEmpty(SearchPhrase))
            {
                FilteredFacultyRecturers.Clear();
                FilteredFacultyRecturers.AddRange(AllFacultyRecturers);
                return;
            }

            var newFilteredFacultyRecurers = AllFacultyRecturers.Select(r => 
            new FacultyRecturers
            {
                Name = r.Name,
                Lecturers = r.Lecturers.Where(l => l.Name.ToLower().Contains(SearchPhrase.ToLower())).ToList()
            }
            ).ToList();
            FilteredFacultyRecturers.Clear();
            FilteredFacultyRecturers.AddRange(newFilteredFacultyRecurers);
        }
    }
}
