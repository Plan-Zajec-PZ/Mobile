namespace MauiCalendarApp.Model;
public class Department
{
    public int Id;
    public string Name { get; set; }
    public bool LastSelected { get; set; }
    public Color Color => LastSelected ? new Color(232, 231, 237) : new Color(255, 255, 255);

    public Department(int id, string name)
    {
        Name = name;
        Id = id;
    }
}
