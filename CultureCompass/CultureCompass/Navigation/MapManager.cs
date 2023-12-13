﻿using CultureCompass.Information;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace CultureCompass.Navigation
{
    internal class MapManager(RouteManager routeManager)
    {
        private Map map;
        private Distance mapSize = Distance.FromMeters(50);
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
                Location = new Location(waypoint.X, waypoint.Y)
            };
            map.Pins.Add(pin);
            routeManager.UpdateMap(map);
        }

        private Polyline polyline;

        public void UpdateRouteLine(Location currentLocation)
        {
            map.MapElements.Remove(polyline);
            Location waypointLocation = routeManager.GetWaypointLocation();

            polyline = new Polyline
            {
                StrokeColor = Colors.Blue,
                StrokeWidth = 12,
                Geopath =
                {
                    currentLocation,
                    waypointLocation,
                }
            };
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