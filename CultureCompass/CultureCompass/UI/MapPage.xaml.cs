using Microsoft.Maui.Maps;
using Microsoft.Maui.Controls.Maps;
namespace CultureCompass.Pages;

public partial class MapPage : ContentPage
{

	public MapPage()
	{
		InitializeComponent();
        
        Location location = new Location(51.588431260179476, 4.776480528591496, 17);
        MapSpan mapSpan = new MapSpan(location, 0.01, 0.01);

        map.MoveToRegion(mapSpan);
        map.IsShowingUser = true;
        map.Pins.Add(new Pin() { Location = location, Label = "Avans Hogeschool"});
    }
}