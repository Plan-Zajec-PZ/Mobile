using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model.Responses;

public class CoursesResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("majors")]
    public List<Course> Courses { get; set; }
}
