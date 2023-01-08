using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;

public class Course
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string FullName { get; set; }

    public string Name =>
        FullName.Split(" (")[0];

    public string Shorthand =>
        FullName.Split('(', ')')[1];
}
