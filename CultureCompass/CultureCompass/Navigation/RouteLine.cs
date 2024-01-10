using CultureCompass.API;
using Microsoft.Maui.Maps;
using Location = Microsoft.Maui.Devices.Sensors.Location;
using Polyline = Microsoft.Maui.Controls.Maps.Polyline;

namespace CultureCompass.Navigation
{
    internal class RouteLine
    {
        private APIManager apiManager = new();
        public int Distance { get; private set; }
        public int Duration { get; private set; }
        public async Task<Polyline> GetRouteLine(string origin, string destination)
        {
            APIResponse result = await apiManager.WriteData(origin, destination);

            Polyline polyline = new Polyline
            {
                StrokeColor = Colors.Blue,
                StrokeWidth = 12
            };

            Duration = 0;
            Distance = 0;
            foreach (Route route in result.Routes)
            {
                foreach (Leg leg in route.Legs)
                {
                    Distance += leg.Distance.Value;
                    Duration += leg.Duration.Value;
                    foreach (Step step in leg.Steps)
                    {
                        polyline.Add(new Location(step.StartLocation.Lat, step.StartLocation.Lng));
                        polyline.Add(new Location(step.EndLocation.Lat, step.EndLocation.Lng));
                    }
                }
            }


            return polyline;
        }

    }
}
