using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;
using CultureCompass.Information;
using CultureCompass.Navigation;
namespace CultureCompass.UI;

public partial class NavigationPage : ContentPage
{

	public NavigationPage()
	{
		InitializeComponent();

        RouteManager routeManager = new RouteManager(this);
        routeManager.SetRoute(new Route()).Wait();
        //Location location = new Location(51.588431260179476, 4.776480528591496, 17);
        //MapSpan mapSpan = new MapSpan(location, 0.01, 0.01);

        //map.IsShowingUser = true;
        //map.Pins.Add(new Pin() { Location = location, Label = "Avans Hogeschool"});
        //map.MoveToRegion(mapSpan);

    }

    public void OnTab1Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new DetailPage());

    }

    public void OnTab2Clicked(object sender, EventArgs e)
    {
        
    }

    public void OnTab3Clicked(object sender, EventArgs e)
    {

    }

    public void UpdateMap(Map map)
    {
        Dispatcher.Dispatch(() =>
        {
            this.Content = map;
        });
    }
}