﻿using CommunityToolkit.Maui.Alerts;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MauiCalendarApp.Model.Responses;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MauiCalendarApp.Services;
public class CalendarApiService : ICalendarApiService
{
    HttpClient _client;

    public CalendarApiService()
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri("https://planzajec.up.railway.app/api/")
        };
        _client.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", "Fummt2MTyUYqTQLcl29ChP9eTHz6NG7qy5wV");
    }

    public List<Department> GetFaculties()
    {
        try
        {
            var response = _client.GetAsync("faculties").Result;

            var text = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonSerializer.Deserialize<ApiResponse<List<Department>>>(text);

            return responseData.Data;
        }
        catch (Exception)
        {
            Toast.Make("Connection error").Show();
            return new List<Department>();
        }
    }

    public List<Course> GetCourses(int facultyId)
    {
        try
        {
            var response = _client.GetAsync($"faculties/{facultyId}/majors").Result;

            var text = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonSerializer.Deserialize<ApiResponse<List<Course>>>(text);

            return responseData.Data;
        }
        catch (Exception)
        {
            Toast.Make("Connection error").Show();
            return new List<Course>();
        }
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
            },
            new Group
            {
                Name = "Gr2",
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
