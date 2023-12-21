using CultureCompass.API;
using System.Collections.Generic;
using Microsoft.Maui.Maps;

namespace CultureCompass.Information
{
    internal class RouteBuilder
    {
        private DatabaseManager databaseManager = new DatabaseManager();

        public List<Route> InitRoutes()
        {
            List<Route> routes = new List<Route>();
            List<Waypoint> waypoints = InitWaypoints();

            Route route1 = new Route
            {
                Name = "Route naar het Kasteel van Breda",
                waypoints = new List<Waypoint>
                {
                waypoints[0],
                waypoints[1]
                }
            };
            route1.TotalWaypoints = route1.waypoints.Count;

            Route route2 = new Route
            {
                Name = "Route naar ValkenBerg Park",
                waypoints = new List<Waypoint>
                {
                waypoints[0],
                waypoints[1],
                waypoints[2],
                }
            };
            route2.TotalWaypoints = route2.waypoints.Count;

            Route route3 = new Route
            {
                Name = "Route naar Begijnhof",
                waypoints = new List<Waypoint>
                {
                waypoints[0],
                waypoints[1],
                waypoints[2],
                waypoints[3],
                waypoints[4],
                }
            };
            route3.TotalWaypoints = route3.waypoints.Count;

            Route route4 = new Route
            {
                Name = "Route naar Stedelijk Museum",
                waypoints = new List<Waypoint>
                {
                waypoints[0],
                waypoints[1],
                waypoints[2],
                waypoints[3],
                waypoints[4],
                waypoints[5],
                waypoints[6],
                }
            };
            route4.TotalWaypoints = route4.waypoints.Count;


            Route route5 = new Route
            {
                Name = "Route naar Maczek Morial",
                waypoints = new List<Waypoint>
                {
                waypoints[0],
                waypoints[1],
                waypoints[2],
                waypoints[3],
                waypoints[4],
                waypoints[5],
                waypoints[6],
                waypoints[7],
                waypoints[8],
                waypoints[9],
                }
            };
            route5.TotalWaypoints = route5.waypoints.Count;

            routes.Add(route1);
            routes.Add(route2);
            routes.Add(route3);
            routes.Add(route4);
            routes.Add(route5);

            return routes;
        }

        private List<Waypoint> InitWaypoints()
        {
            List<Waypoint> waypoints = new List<Waypoint>();

            for (int i = 1; i <= 10; i++)
            {
                waypoints.Add(databaseManager.GetWaypoint(i));
            }

            return waypoints;
        }
    }
}
