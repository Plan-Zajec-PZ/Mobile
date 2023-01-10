using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;
public class Legend
{
    [JsonPropertyName("fullname")]
    public string Name { get; set; }

    [JsonPropertyName("abbreviation")]
    public string Shorthand { get; set; }

}
