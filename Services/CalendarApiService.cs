using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;

namespace MauiCalendarApp.Services;
public class CalendarApiService : ICalendarApiService
{
    public List<Department> GetDepartments()
    {
        return new List<Department>
        {
            new Department("Wydział Nauk o Zdrowiu i Kulturze Fizycznej"),
            new Department("Wydział Nauk Technicznych i Ekonomicznych"),
            new Department("Wydział Nauk Społęcznych i Humanistycznych")
        };
    }
}
