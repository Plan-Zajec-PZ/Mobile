using CommunityToolkit.Maui.Views;
using MauiCalendarApp.Model;
using MauiCalendarApp.Model.Requests;

namespace MauiCalendarApp.View;

public partial class SpecializationPopup : Popup
{
	private Course Course;

	public SpecializationPopup(Course course)
	{
		InitializeComponent();
		Course = course;
		button1.Text = course.Specializations[0].ShortHand;
        button2.Text = course.Specializations[1].ShortHand;
    }

	private void Button1_Clicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync(nameof(LessonsPage), true, new Dictionary<string, object>
		{
			{
                "Data",
				new LessonsRequest{ CourseId = Course.Id, SpecializationId = Course.Specializations[0].Id }
			}
        });

        Close();
    }

	private void Button2_Clicked(object sender, EventArgs e)
	{
        Shell.Current.GoToAsync(nameof(LessonsPage), true, new Dictionary<string, object>
        {
            {
                "Data",
                new LessonsRequest{ CourseId = Course.Id, SpecializationId = Course.Specializations[1].Id }
            }
        });

        Close();
    }
}