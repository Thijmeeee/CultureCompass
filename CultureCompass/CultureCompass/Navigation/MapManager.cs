using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CultureCompass.Information;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace CultureCompass.Navigation
{
    internal class MapManager(RouteManager routeManager)
    {
        private Map map;
        private Distance mapSize = Distance.FromMeters(50);
        private Polyline polyline;
        private RouteLine routeLine = new();
        public async Task<Map> CreateMap()
        {
            Location location = await routeManager.GetCurrentLocation();

            if (location == null)
            {
                location = new Location(51.5859361157708, 4.792374891466518);
            }

            MapSpan mapSpan = MapSpan.FromCenterAndRadius(location, mapSize);

            map = new Map(mapSpan)
            {
                MapType = MapType.Street,
                IsTrafficEnabled = true,
                IsScrollEnabled = true,
                IsZoomEnabled = true,
                IsShowingUser = true,
            };
            return map;
        }

        public void AddWaypointPin(Waypoint waypoint)
        {
            Pin pin = new Pin
            {
                Label = waypoint.Name,
                Type = PinType.Place,
                Location = new Location(waypoint.Y, waypoint.X)
            };
            map.Pins.Add(pin);
            pin.MarkerClicked += (s, args) => routeManager.PinClickedGoToDetailPage(waypoint);
            routeManager.UpdateMap(map);
        }

        public async void UpdateRouteLine(Location currentLocation)
        {
            map.MapElements.Remove(polyline);

            Location waypointLocation = routeManager.GetWaypointLocation();

            string origin = currentLocation.Latitude + "," + currentLocation.Longitude;
            string destination = waypointLocation.Latitude + "," + waypointLocation.Longitude;

            polyline = await routeLine.GetRouteLine(origin, destination);

            map.MapElements.Add(polyline);
            routeManager.UpdateMap(map);
        }

        public void CenterMap(Location location)
        {
            MapSpan mapSpan = MapSpan.FromCenterAndRadius(location, mapSize);
            map.MoveToRegion(mapSpan);
        }
    }
}
