using System.Resources;
using CultureCompass.Information;

namespace CultureCompass.UI;

public partial class WaypointPage : ContentPage
{
	private Waypoint currentWaypoint;
	public WaypointPage(Waypoint waypoint)
	{
		currentWaypoint = waypoint;
        InitializeComponent();
        InitializeValues();
    }

	public void InitializeValues()
	{
		Title = currentWaypoint.Name;
		ImageWaypoint.Source = currentWaypoint.ImagePath;
		BuildYearLabel.Text = currentWaypoint.Year.ToString();
        DescriptionLabel.Text = currentWaypoint.InfoEnglish;
	}

	public void BackToRouteButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();

	}
}