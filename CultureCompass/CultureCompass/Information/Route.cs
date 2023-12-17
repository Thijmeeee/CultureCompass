using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls.Maps;

namespace CultureCompass.Information
{
    public partial class Route : ObservableObject
    {
        [ObservableProperty]
        public List<Waypoint> waypoints = new List<Waypoint>();

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public double distance;
        
    }
}
