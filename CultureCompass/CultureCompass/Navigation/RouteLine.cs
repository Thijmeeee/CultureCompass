using CultureCompass.API;
using Location = Microsoft.Maui.Devices.Sensors.Location;
using Polyline = Microsoft.Maui.Controls.Maps.Polyline;

namespace CultureCompass.Navigation
{
    internal class RouteLine
    {
        private APIManager apiManager = new();
        public async Task<Polyline> GetRouteLine(string origin, string destination)
        {
            APIResponse result = await apiManager.WriteData(origin, destination);

            Polyline polyline = new Polyline()
            {
                StrokeColor = Colors.Blue,
                StrokeWidth = 12
            };

            foreach (Route route in result.Routes)
            {
                foreach (Leg leg in route.Legs)
                {
                    foreach (Step step in leg.Steps)
                    {
                        polyline.Add(new Location(step.StartLocation.Lat, step.StartLocation.Lng));
                    }
                }
            }
            return polyline;
        }
    }
}
