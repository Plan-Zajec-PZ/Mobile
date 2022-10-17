using MauiCalendarApp.Interfaces;

namespace MauiCalendarApp.Services;
public class CalendarApiService : ICalendarApiService
{
    public List<string> GetDepartments()
    {
        return new List<string>
        {
            "Wydział Nauk o Zdrowiu i Kulturze Fizycznej",
            "Wydział Nauk Technicznych i Ekonomicznych",
            "Wydział Nauk Społęcznych i Humanistycznych"
        };
    }
}
