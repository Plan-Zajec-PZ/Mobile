﻿namespace MauiCalendarApp.Model;

public class DayLesson
{
    public DateTime Date { get; set; }
    public List<Lesson> Lessons { get; set; }

    public string NameOfTheDay => Date.DayOfWeek.ToString();
}
