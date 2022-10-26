using MauiCalendarApp.Model;

namespace MauiCalendarApp.Interfaces;
public interface ICalendarApiService
{
    public List<Department> GetDepartments();
    List<Subject> GetSubjects(int departmentId);
}
