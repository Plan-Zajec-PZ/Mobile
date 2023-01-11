using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model.Responses;

public class LecturerLessonsResponse
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("faculty")]
    public Faculty Faculty { get; set; }

    [JsonPropertyName("schedule")]
    public LecturerShedule Schedule { get; set; }
}
