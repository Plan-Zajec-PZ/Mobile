using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model.Responses;

public class LessonsResponse
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("groups")]
    public List<Group> Groups { get; set; }

    [JsonPropertyName("abbreviationLegend")]
    public List<Legend> Legends { get; set; }
}
