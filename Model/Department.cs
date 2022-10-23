﻿namespace MauiCalendarApp.Model;
public class Department
{
    public string Name { get; set; }
    public bool LastSelected { get; set; }
    public Color Color => LastSelected ? new Color(232, 231, 237) : new Color(255, 255, 255);

    public Department(string name)
    {
        Name = name;
    }
}
