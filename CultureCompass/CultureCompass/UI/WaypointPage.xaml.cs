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
		Title = $"Informatie over {currentWaypoint.Name}";
		BuildYearLabel.Text = currentWaypoint.Year.ToString();
		DescriptionLabel.Text = "test hier";
	}

	public void BackToRouteButton_Clicked(object sender, EventArgs e)
	{
		Navigation.PopAsync();

	}
}