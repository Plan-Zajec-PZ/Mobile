using System.Globalization;
using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;

public class Shedule
{
    [JsonPropertyName("day")]
    public string Day { get; set; }

    [JsonPropertyName("rows")]
    public List<List<string>> Data { get; set; }

    public List<Lesson> Lessons =>
        Data.Select(rows => new Lesson
        {
            Time = rows[0],
            Subject = rows[1],
            Teacher = rows[2],
            Classroom = rows[3]
        }).ToList();

    public string NameOfTheDay => Day.Split(" ")[0];

    public DateTime Date =>
        DateTime.Parse(Day.Split(" ")[1]);

    public string WeekOfYear =>
        $"({FirstDayOfWeek().ToShortDateString()} - {LastDayOfWeek().ToShortDateString()}) Tydzień {CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(Date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday)}";

    private DateTime FirstDayOfWeek()
    {
        var date = new DateTime(Date.Ticks);
        while (true)
        {
            date = date.AddDays(-1);

            if (CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(Date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday) != CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday))
                return date.AddDays(1);
        }
    }
    private DateTime LastDayOfWeek()
    {
        return FirstDayOfWeek().AddDays(6);
    }
}
