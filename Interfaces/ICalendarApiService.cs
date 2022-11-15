using MauiCalendarApp.Model;

namespace MauiCalendarApp.Interfaces;
public interface ICalendarApiService
{
    List<Department> GetDepartments();
    List<Course> GetSubjects(int departmentId);
    List<Group> GetLessons();
    List<Legend> GetLegends();
    List<string> GetWeeks();
}
