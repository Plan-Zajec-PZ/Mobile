using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model.Responses;
public class ApiResponse<T>
{
    [JsonPropertyName("data")]
    public T Data { get; set; }
}
