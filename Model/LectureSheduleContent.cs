using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;

public class LectureSheduleContent
{
    [JsonPropertyName("date")]
    public string Date { get; set; }

    [JsonPropertyName("dailyShedule")]
    public List<List<string>> Data { get; set; }

    public List<Lesson> Lessons =>
        Data.Select(rows => new Lesson
        {
            Subject = rows[0],
            Time = rows[1],
            Teacher = rows[2],
            Classroom = rows[3]
        }).ToList();
}
