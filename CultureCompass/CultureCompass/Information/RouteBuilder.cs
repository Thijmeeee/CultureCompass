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
                },
                TotalWaypoints = 2
            };

            Route route2 = new Route
            {
                Name = "Route naar ValkenBerg Park Breda",
                waypoints = new List<Waypoint>
                {
                waypoints[0],
                waypoints[1],
                waypoints[2],
                },
                TotalWaypoints = 3
            };

            Route route3 = new Route
            {
                Name = "Route naar Begijnhof Route",
                waypoints = new List<Waypoint>
                {
                waypoints[0],
                waypoints[1],
                waypoints[2],
                waypoints[3],
                waypoints[4],
                },
                TotalWaypoints = 5
            };

            Route route4 = new Route
            {
                Name = "Route naar Stedelijk Museum Breda",
                waypoints = new List<Waypoint>
                {
                waypoints[0],
                waypoints[1],
                waypoints[2],
                waypoints[3],
                waypoints[4],
                waypoints[5],
                waypoints[6],
                },
                TotalWaypoints = 7
            };


            Route route5 = new Route
            {
                Name = "Route naar Maczek Morial Breda",
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
                },
                TotalWaypoints = 10
            };

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
