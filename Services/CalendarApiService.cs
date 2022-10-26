using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;

namespace MauiCalendarApp.Services;
public class CalendarApiService : ICalendarApiService
{
    public List<Department> GetDepartments()
    {
        return new List<Department>
        {
            new Department(0, "Wydział Nauk o Zdrowiu i Kulturze Fizycznej"),
            new Department(1, "Wydział Nauk Technicznych i Ekonomicznych"),
            new Department(2, "Wydział Nauk Społęcznych i Humanistycznych")
        };
    }

    public List<Subject> GetSubjects(int departmentId)
    {
        return new List<Subject>
        {
            new(1, 0, "Zdrowie", "Zdr"), new(2, 0, "Kultura", "Kul"), new(3, 0, "Fizyczność", "FiZ"),
            new(4, 1, "Technika", "Tech"), new(5, 1, "Ekonomia", "EkO"), new(6, 1, "Techonomia", "TEkO"),
            new(7, 2, "Społeczeństwo", "Spo"), new(8, 2, "Humanizm", "HUM"), new(9, 2, "Filozofia", "Filo")
        }
        .Where(s => s.DepId == departmentId).ToList();
    }
}
