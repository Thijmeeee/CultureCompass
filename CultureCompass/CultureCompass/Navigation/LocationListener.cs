using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Maps;

namespace CultureCompass.Navigation
{
    internal class LocationListener(RouteManager routeManager, MapManager mapManager)
    {
        private double distanceThreshold = 20;

        public async void StartListening()
        {
            try
            {
                Geolocation.LocationChanged += Geolocation_LocationChanged;
                var request = new GeolocationListeningRequest(GeolocationAccuracy.Best);
                var success = await Geolocation.StartListeningForegroundAsync(request);

                string status = success
                    ? "Started listening for foreground location updates"
                    : "Couldn't start listening";
            }
            catch (Exception ex)
            {
                // Unable to start listening for location changes
            }

            Thread thread = new Thread(() =>
            {
                Thread.Sleep(1000);
                StopListening();
            });
            thread.Start();
        }

        public void StopListening()
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

        private void Geolocation_LocationChanged(object sender, GeolocationLocationChangedEventArgs e)
        {
            mapManager.UpdateRouteLine(e.Location);
            mapManager.CenterMap(e.Location);

            Location currentWaypoint = routeManager.GetWaypointLocation();
            if (currentWaypoint != null)
            {
                Distance distance = Distance.BetweenPositions(e.Location, currentWaypoint);

                string text = "distance to waypoint: " + distance.Meters + "m";
                ToastDuration duration = ToastDuration.Short;
                double fontSize = 14;

                var toast = Toast.Make(text, duration, fontSize);
                toast.Show();

                if (distance.Meters <= distanceThreshold)
                {
                    routeManager.ArrivedAtWaypoint();
                }
            }
        }
    }
}
