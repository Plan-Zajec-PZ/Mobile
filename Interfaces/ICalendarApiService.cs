using MauiCalendarApp.Model;
using MauiCalendarApp.Model.Requests;
using MauiCalendarApp.Model.Responses;

namespace MauiCalendarApp.Interfaces;
public interface ICalendarApiService
{
    List<Department> GetFaculties();
    List<Course> GetCourses(int facultyId);
    LessonsResponse GetLessons(LessonsRequest lessonsRequest);
}
