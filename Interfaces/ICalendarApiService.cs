using MauiCalendarApp.Model;

namespace MauiCalendarApp.Interfaces;
public interface ICalendarApiService
{
    List<Department> GetFaculties();
    List<Course> GetCourses(int facultyId);
    List<Group> GetLessons();
    List<Legend> GetLegends();
    List<string> GetWeeks();
}
