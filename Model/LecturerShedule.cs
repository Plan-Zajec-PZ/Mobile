using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;

public class LecturerShedule
{
    [JsonPropertyName("content")]
    public LectureSheduleContent Data { get; set; }

    [JsonPropertyName("legend")]
    public List<Legend> Legends { get; set; }
}
