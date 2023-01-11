using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;

public class DailySchedule
{
    [JsonPropertyName("class")]
    public string Class { get; set; }

    [JsonPropertyName("hours")]
    public string Hours { get; set; }

    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    [JsonPropertyName("classroom")]
    public string Classroom { get; set; }
}
