namespace MauiCalendarApp.Model;
public class Subject
{
    public int Id { get; set; }
    public int DepId { get; set; }
    public string Name { get; set; }
    public string Shorthand { get; set; }

    public Subject(int id,int depId, string name, string shorthand)
    {
        Name = name;
        Shorthand = shorthand;
        Id = id;
        DepId = depId;
    }
}
