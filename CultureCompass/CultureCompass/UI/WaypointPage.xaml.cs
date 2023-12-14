using CultureCompass.Information;

namespace CultureCompass.UI;

public partial class WaypointPage : ContentPage
{
	private NavigationPage NavigationPage;
	private Waypoint currentWaypoint;
	public WaypointPage(NavigationPage navigationPage, Waypoint waypoint)
	{
		NavigationPage = navigationPage;
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