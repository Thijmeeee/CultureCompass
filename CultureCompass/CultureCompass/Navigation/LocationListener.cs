using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using Microsoft.Maui.Maps;

namespace CultureCompass.Navigation
{
    public class LocationListener(RouteManager routeManager, MapManager mapManager)
    {
        private double distanceThreshold = 20;
        private Thread updateRouteLineThread;

        private Location lastLocation;
        private bool running;

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

            updateRouteLineThread = new Thread(() =>
            {
                running = true;
                while (running)
                {
                    if (lastLocation != null)
                    {
                        //wait 15 seconds to minimize API calls
                        Device.InvokeOnMainThreadAsync(() =>
                        {
                            mapManager.UpdateRouteLine(lastLocation);
                        });
                        Thread.Sleep(15000);
                    }
                }
            });
            updateRouteLineThread.Start();
        }

        public bool GetRunning()
        {
            return this.running;
        }

        public void StopListening()
        {
            running = false;
            try
            {
                Geolocation.LocationChanged -= Geolocation_LocationChanged;
                Geolocation.StopListeningForeground();
            }
            catch (Exception ex)
            {
                // Unable to stop listening for location changes
            }
        }


        private void Geolocation_LocationChanged(object sender, GeolocationLocationChangedEventArgs e)
        {
            lastLocation = e.Location;
            mapManager.CenterMap(lastLocation);

            Location currentWaypoint = routeManager.GetWaypointLocation();
            if (currentWaypoint != null)
            {
                Distance distance = Distance.BetweenPositions(e.Location, currentWaypoint);

                //string text = "distance to waypoint: " + distance.Meters + "m";
                //ToastDuration duration = ToastDuration.Short;
                //double fontSize = 14;

                //var toast = Toast.Make(text, duration, fontSize);
                //toast.Show();

                if (distance.Meters <= distanceThreshold)
                {
                    routeManager.ArrivedAtWaypoint();
                }
            }
        }
    }
}
