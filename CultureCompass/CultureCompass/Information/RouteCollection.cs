namespace CultureCompass.Information
{
    internal class RouteCollection
    {
        public Routes routes;

        public RouteCollection()
        {
            RouteBuilder routeBuilder = new RouteBuilder();
            Routes routes = new Routes();
            routes.routeList = routeBuilder.InitRoutes();
        }
    }
}
