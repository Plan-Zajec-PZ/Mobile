using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;

public class LecturerSheduleContent
{
    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("dailySchedule")]
    public List<DailySchedule> Data { get; set; }

    public List<Lesson> Lessons =>
        Data.Select(schedule => new Lesson
        {
            Subject = schedule.Subject,
            Time = schedule.Hours,
            Teacher = schedule.Class,
            Classroom = schedule.Classroom
        }).ToList();
}
