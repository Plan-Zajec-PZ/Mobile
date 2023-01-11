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

    public static List<int> FavouriteCoursesId
    {
        get
        {
            var rawData = AppSettings.GetValueOrDefault(nameof(FavouriteCoursesId), JsonSerializer.Serialize(new List<int>()));
            return JsonSerializer.Deserialize<List<int>>(rawData);
        }
        set
        {
            AppSettings.AddOrUpdateValue(nameof(FavouriteCoursesId), JsonSerializer.Serialize(value));
        }
    }
}
