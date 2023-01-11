using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;

public class LecturerShedule
{
    [JsonPropertyName("content")]
    public List<LecturerSheduleContent> Data { get; set; }

    [JsonPropertyName("legend")]
    public List<Legend> Legends { get; set; }
}
