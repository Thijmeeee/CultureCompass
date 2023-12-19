using CultureCompass.Information;
using CultureCompass.Notification;
using CultureCompass.UI;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Map = Microsoft.Maui.Controls.Maps.Map;
using NavigationPage = CultureCompass.UI.NavigationPage;


//https://learn.microsoft.com/en-us/dotnet/maui/user-interface/controls/map?view=net-maui-8.0
//https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/appmodel/maps?view=net-maui-8.0&tabs=android
//https://learn.microsoft.com/en-us/dotnet/maui/platform-integration/device/geolocation?view=net-maui-8.0&tabs=android
//https://developers.google.com/maps/documentation/directions/get-directions#DirectionsResponses


namespace CultureCompass.Navigation
{
    internal class RouteManager
    {
        private NavigationPage navigationPage;
        private LocationListener locationListener;
        private MapManager mapManager;
        private NotificationManager notificationManager;

        private Route route;
        private int routeIndex;


        public RouteManager(NavigationPage navigationPage)
        {
            this.navigationPage = navigationPage;

            this.mapManager = new MapManager(this);
            mapManager.CreateMap().Wait();


            this.locationListener = new LocationListener(this, mapManager);
            locationListener.StartListening();

            this.notificationManager = new NotificationManager();
            this.notificationManager.NotificationType = new PushNotification();
        }

        public async Task<Location> GetCurrentLocation()
        {
            try
            {
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

        public Location GetWaypointLocation()
        {
            try
            {
                Waypoint waypoint = route.waypoints[routeIndex];
                return new Location(waypoint.Y, waypoint.X);
            }
            catch (Exception e)
            {
                //route empty or route finished
                return null;
            }
        }

        public void ArrivedAtWaypoint()
        {
            notificationManager.SendNotification(route.waypoints[routeIndex].Name, "test");

            routeIndex++;

            if (route.waypoints.Count > routeIndex)
            {
                RouteToNextPoint().Wait();
            }
            else
            {
                //end of route
                locationListener.StopListening();
            }
        }

        public async Task SetRoute(Route route)
        {
            this.routeIndex = 0;
            this.route = route;

            foreach (Waypoint waypoint in route.waypoints)
            {
                mapManager.AddWaypointPin(waypoint);
            }

            await RouteToNextPoint();
        }

        private async Task RouteToNextPoint()
        {
            Waypoint waypoint = route.waypoints[routeIndex];
        }

        public void UpdateMap(Map map)
        {
            navigationPage.UpdateMap(map);
        }

        public void PinClickedGoToDetailPage(Waypoint waypoint)
        {
            navigationPage.GoToWaypointPage(waypoint);
        }
    }
}
