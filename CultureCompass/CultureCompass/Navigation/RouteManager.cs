﻿using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CultureCompass.Information;
using Map = Microsoft.Maui.Controls.Maps.Map;
using CommunityToolkit.Maui.Alerts;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using CommunityToolkit.Maui.Core;


//https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/map?view=net-maui-8.0
//https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/maps?view=net-maui-8.0&tabs=android
//https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device/geolocation?view=net-maui-8.0&tabs=android
//https://developers.google.com/maps/documentation/directions/get-directions#DirectionsResponses


namespace CultureCompass.Navigation
{
    internal class RouteManager
    {
        private Map map;
        private Route route;
        private MainPage mainPage;
        private int routeIndex;
        private double distanceThreshold = 20;

        public RouteManager(MainPage mainPage)
        {
            this.mainPage = mainPage;
            CreateMap().Wait();
        }

        public async Task CreateMap()
        {
            Location location = await GetCurrentLocation();

            if (location == null)
            {
                location = new Location(51.5859361157708, 4.792374891466518);
            }

            MapSpan mapSpan = new MapSpan(location, 0.005, 0.005);

            map = new Map(mapSpan)
            {
                MapType = MapType.Street,
                IsTrafficEnabled = true,
                IsScrollEnabled = true,
                IsZoomEnabled = true,
                IsShowingUser = true,
            };

            //Circle circle = new Circle()
            //{
            //    Center = location,
            //    Radius = Distance.FromMeters(50),
            //    StrokeColor = Colors.Aqua,
            //    StrokeWidth = 8,
            //    FillColor = Color.FromRgba(255, 0, 0, 64)
            //};
            //map.MapElements.Add(circle);

            mainPage.UpdateMap(map);
            OnStartListening();
        }

        public async Task<Location> GetCurrentLocation()
        {
            try
            {
                //GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(5));

                //Location location = await Geolocation.Default.GetLocationAsync(request);
                Location location = await Geolocation.Default.GetLastKnownLocationAsync();

                if (location != null)
                    return location;
            }

            catch (Exception ex)
            {
                // Unable to get location
            }

            return null;
        }


        public async Task SetRoute(Route route)
        {
            this.routeIndex = 0;
            this.route = route;
            if (route.waypoints.Count == 0)
            {
                //test code
                route.waypoints = new List<Waypoint>()
                {
                    new()
                    {
                        ID = 0,
                        X = 51.58903179679572,
                        Y = 4.775741802339474,
                        Name = "Test"
                    }
                };
            }

            await RouteToNextPoint();
        }

        private async Task RouteToNextPoint()
        {
            Waypoint waypoint = route.waypoints[routeIndex];

            Pin pin = new Pin
            {
                Label = waypoint.Name,
                Type = PinType.Place,
                Location = new Location(waypoint.X, waypoint.Y)
            };
            map.Pins.Add(pin);

            Location currentLocation = await GetCurrentLocation();

            Polyline polyline = new Polyline
            {
                StrokeColor = Colors.Blue,
                StrokeWidth = 12,
                Geopath =
                {
                    currentLocation,
                    new Location(waypoint.X, waypoint.Y),
                }
            };

            map.MapElements.Add(polyline);

            mainPage.UpdateMap(map);
        }

        async void OnStartListening()
        {
            try
            {
                Geolocation.LocationChanged += Geolocation_LocationChanged;
                var request = new GeolocationListeningRequest(GeolocationAccuracy.High);
                var success = await Geolocation.StartListeningForegroundAsync(request);

                string status = success
                    ? "Started listening for foreground location updates"
                    : "Couldn't start listening";
            }
            catch (Exception ex)
            {
                // Unable to start listening for location changes
            }
        }

        void OnStopListening()
        {
            try
            {
                Geolocation.LocationChanged -= Geolocation_LocationChanged;
                Geolocation.StopListeningForeground();
                string status = "Stopped listening for foreground location updates";
            }
            catch (Exception ex)
            {
                // Unable to stop listening for location changes
            }
        }

        void Geolocation_LocationChanged(object sender, GeolocationLocationChangedEventArgs e)
        {
            Location currentWaypoint = new Location(route.waypoints[routeIndex].X, route.waypoints[routeIndex].Y);
            Distance distance = Distance.BetweenPositions(e.Location, currentWaypoint);

            string text = "distance to waypoint: " + distance.Meters + "m";
            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var toast = Toast.Make(text, duration, fontSize);
            toast.Show();

            if (distance.Meters <= distanceThreshold)
            {
                routeIndex++;

                //send notification that user is close to waypoint

                if (route.waypoints.Count > routeIndex)
                {
                    RouteToNextPoint().Wait();
                }
                else
                {
                    //route ended
                    text = "end of route";
                    toast = Toast.Make(text, duration, fontSize);
                    toast.Show();

                    OnStopListening();
                }
            }
        }
    }
}
