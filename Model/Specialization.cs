using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;

public class Specialization
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    public string ShortHand =>
        Name.Split('(')[0];
}
