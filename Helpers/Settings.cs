using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace MauiCalendarApp.Helpers;
public static class Settings
{
    private static ISettings AppSettings
    {
        get
        {
            return CrossSettings.Current;
        }
    }

    public static string? LastSelectedDepartmentName
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
}
