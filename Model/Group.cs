using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;
public class Group
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("schedule")]
    public List<Shedule> ShedulePlan { get; set; }
}
