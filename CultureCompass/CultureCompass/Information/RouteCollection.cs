namespace CultureCompass.Information
{
    internal class RouteCollection
    {
        public Routes routes;
        public RouteCollection()
        {
            RouteBuilder routeBuilder = new RouteBuilder();
            routes = new Routes();
            routes.RouteList = routeBuilder.InitRoutes();
        }
    }
}
