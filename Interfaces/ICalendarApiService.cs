using MauiCalendarApp.Model;
using MauiCalendarApp.Model.Requests;
using MauiCalendarApp.Model.Responses;

namespace MauiCalendarApp.Interfaces;
public interface ICalendarApiService
{
    List<Faculty> GetFaculties();
    List<Course> GetCourses(int facultyId);
    LessonsResponse GetLessons(LessonsRequest lessonsRequest);
    List<Lecturer> GetLecturersForFaculty(int facultyId);
    LecturerLessonsResponse GetLessonsForLecturer(int lecturerId);
}
