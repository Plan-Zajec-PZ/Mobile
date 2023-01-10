using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;

public class Course
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("specializations")]
    public List<Specialization> Specializations { get; set; }

    public string Shorthand =>
        string.Join('|',Specializations.Select(s => s.Name.Split(" (")[0]));
}
