using CommunityToolkit.Maui.Alerts;
using MauiCalendarApp.Interfaces;
using MauiCalendarApp.Model;
using MauiCalendarApp.Model.Requests;
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

    public List<Faculty> GetFaculties()
    {
        try
        {
            var response = _client.GetAsync("faculties").Result;

            var text = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonSerializer.Deserialize<ApiResponse<List<Faculty>>>(text);

            return responseData.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Toast.Make("Connection error").Show();
            return new List<Faculty>();
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
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Toast.Make("Connection error").Show();
            return new List<Course>();
        }
    }

    public LessonsResponse GetLessons(LessonsRequest lessonsRequest)
    {
        try
        {
            var response = _client.GetAsync(
                $"majors/{lessonsRequest.CourseId}/specializations/{lessonsRequest.SpecializationId}"
                ).Result;

            var text = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonSerializer.Deserialize<ApiResponse<LessonsResponse>>(text);

            return responseData.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Toast.Make("Connection error").Show();
            return new LessonsResponse();
        }
    }

    public List<Lecturer> GetLecturersForFaculty(int facultyId)
    {
        try
        {
            var response = _client.GetAsync($"lecturers?faculty={facultyId}").Result;

            var text = response.Content.ReadAsStringAsync().Result;
            var responseData = JsonSerializer.Deserialize<ApiResponse<List<Lecturer>>>(text);

            return responseData.Data;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            Toast.Make("Connection error").Show();
            return new List<Lecturer>();
        }
    }
}
