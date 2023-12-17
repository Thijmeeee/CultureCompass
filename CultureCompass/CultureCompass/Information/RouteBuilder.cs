namespace CultureCompass.Information
{
    internal class RouteBuilder
    {
        private DatabaseManager databaseManager = new DatabaseManager();
      
        public List<Route> InitRoutes()
        {
            Route route = new Route();
            List<Route> routes = new List<Route>();
           
            route.waypoints = InitWaypoints();
            route.name = "bert";
            route.distance = 10.0;

            routes.Add(route);

            return routes;

        }

        private List<Waypoint> InitWaypoints()
        {
            return databaseManager.GetAllWaypoints();
        }


    }
}
