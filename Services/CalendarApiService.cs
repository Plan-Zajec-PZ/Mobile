using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;

namespace MauiCalendarApp.Services;
public class CalendarApiService : ICalendarApiService
{
    public List<Department> GetDepartments()
    {
        return new List<Department>
        {
            new Department(0, "Wydział Nauk o Zdrowiu i Kulturze Fizycznej"),
            new Department(1, "Wydział Nauk Technicznych i Ekonomicznych"),
            new Department(2, "Wydział Nauk Społęcznych i Humanistycznych")
        };
    }

    public List<Course> GetSubjects(int departmentId)
    {
        return new List<Course>
        {
            new(1, 0, "Zdrowie", "Zdr"), new(2, 0, "Kultura", "Kul"), new(3, 0, "Fizyczność", "FiZ"),
            new(4, 1, "Technika", "Tech"), new(5, 1, "Ekonomia", "EkO"), new(6, 1, "Techonomia", "TEkO"),
            new(7, 2, "Społeczeństwo", "Spo"), new(8, 2, "Humanizm", "HUM"), new(9, 2, "Filozofia", "Filo")
        }
        .Where(s => s.DepId == departmentId).ToList();
    }

    public List<Group> GetLessons()
    {
        return new List<Group>
        {
            new Group
            {
                Name = "Gr1",
                LessonPlans = new List<DayLesson>
                {
                    new DayLesson
                    {
                        Date = DateTime.Now,
                        Lessons = new List<Lesson>
                        {
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            }
                        }
                    },
                    new DayLesson
                    {
                        Date = DateTime.Now.AddDays(1),
                        Lessons = new List<Lesson>
                        {
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            }
                        }
                    },
                    new DayLesson
                    {
                        Date = DateTime.Now.AddDays(2),
                        Lessons = new List<Lesson>
                        {
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            },
                            new Lesson
                            {
                                Subject = "Informatyka",
                                Teacher = "Matejko",
                                Classroom = "200A"
                            }
                        }
                    }
                }
            }
        };
    }

    public List<Legend> GetLegends()
    {
        return new List<Legend>
        {
            new Legend{ Subject = "Inf", Name = "Informatyka" },
            new Legend{ Subject = "PzoD", Name = "Przodek kuchenny" }
        };
    }

    public List<string> GetWeeks()
    {
        return new (){
            "42", "43", "44", "45"
        };
    }
}
