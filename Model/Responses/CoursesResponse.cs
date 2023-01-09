using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model.Responses;

public class CoursesResponse
{
    [JsonPropertyName("majors")]
    public List<Course> Courses { get; set; }
}
