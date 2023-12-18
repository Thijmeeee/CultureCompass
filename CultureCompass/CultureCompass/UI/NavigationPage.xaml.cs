using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
using CultureCompass.Information;
using CultureCompass.Navigation;
namespace CultureCompass.UI;

public partial class NavigationPage : ContentPage
{
    public NavigationPage(Route route)
	{
		InitializeComponent();

        RouteManager routeManager = new RouteManager(this);
        routeManager.SetRoute(route).Wait();
    }
    public void UpdateMap(Map newMap)
    {
        Dispatcher.Dispatch(() =>
        {
            stacklayout.Children.Remove(mapNavigation);

            stacklayout.Children.Add(newMap);
            mapNavigation = newMap;
        });
    }

    public void GoToWaypointPage(Waypoint waypoint)
    {
        Navigation.PushAsync(new WaypointPage(waypoint));
    }

    private void StopRouteButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new MainPage());
    }
}