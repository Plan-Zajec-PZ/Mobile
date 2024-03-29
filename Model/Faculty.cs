﻿using System.Text.Json.Serialization;

namespace MauiCalendarApp.Model;
public class Faculty
{
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonIgnore]
    public bool LastSelected { get; set; }
    [JsonIgnore]
    public Color Color => LastSelected ? new Color(232, 231, 237) : new Color(255, 255, 255);
}
