using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CultureCompass.Information;
using CultureCompass.Navigation;
using CultureCompass.UI;
using NavigationPage = CultureCompass.UI.NavigationPage;

namespace CultureCompassTest
{
    public class Navigation_Test
    {

        [Fact]
        public void SetRouteTest()
        {
            RouteManager routeManager = new RouteManager(null);

            Route route = new Route();
            route.waypoints = null;
            routeManager.SetRoute(route);
            Assert.Null(routeManager.GetRoute());


            route = new Route();
            List<Waypoint> waypoints = new List<Waypoint>()
            {
                new Waypoint(),
                new Waypoint(),
                new Waypoint()
            };
            route.waypoints = waypoints;
            routeManager.SetRoute(route);

            Assert.NotNull(routeManager.GetRoute());
            Assert.Equal(routeManager.GetRoute().waypoints.Count, 3);
        }

        [Fact]
        public void ArrivedAtWaypointTest()
        {
            RouteManager routeManager = new RouteManager(null);

            Route route = new Route();
            List<Waypoint> waypoints = new List<Waypoint>()
            {
                new Waypoint(),
                new Waypoint(),
            };
            route.waypoints = waypoints;
            routeManager.SetRoute(route);

            routeManager.ArrivedAtWaypoint();
            Assert.True(routeManager.GetLocationListener().GetRunning());

            routeManager.ArrivedAtWaypoint();
            Assert.False(routeManager.GetLocationListener().GetRunning());
        }

        [Fact]
        public void GetWaypointLocationTest()
        {
            RouteManager routeManager = new RouteManager(null);

            Route route = new Route();
            List<Waypoint> waypoints = new List<Waypoint>()
            {
                new Waypoint()
                {
                X = 4.774812,
                Y = 51.58905,
            }
        };
            route.waypoints = waypoints;
            routeManager.SetRoute(route);

            Location location = routeManager.GetWaypointLocation();
            Location check = new Location(51.58905, 4.774812);
            Assert.Equal(location, check);
        }
    }
}
