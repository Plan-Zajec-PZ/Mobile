using MauiCalendarApp.Model;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Text.Json;

namespace MauiCalendarApp.Helpers;
public static class Settings
{
    private static ISettings AppSettings =>
        CrossSettings.Current;

    public static string LastSelectedDepartmentName
    {
        get
        {
            return AppSettings.GetValueOrDefault(nameof(LastSelectedDepartmentName), null);
        }
        set
        {
            AppSettings.AddOrUpdateValue(nameof(LastSelectedDepartmentName), value);
        }
    }

    public static List<Subject> FavouriteSubjects
    {
        get
        {
            var rawData = AppSettings.GetValueOrDefault(nameof(FavouriteSubjects), string.Empty);
            return JsonSerializer.Deserialize<List<Subject>>(rawData);
        }
        set
        {
            AppSettings.AddOrUpdateValue(nameof(FavouriteSubjects), JsonSerializer.Serialize(value));
        }
    }
}
