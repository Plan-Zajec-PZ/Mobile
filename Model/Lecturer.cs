using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model
{
    public class Lecturer
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
