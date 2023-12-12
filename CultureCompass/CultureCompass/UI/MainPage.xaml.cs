using CultureCompass.Information;
using CultureCompass.Navigation;
using Map = Microsoft.Maui.Controls.Maps.Map;

namespace CultureCompass
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            RouteManager routeManager = new RouteManager(this);
            routeManager.SetRoute(new Route());
        }

        public void UpdateMap(Map map)
        {
            Dispatcher.Dispatch(() =>
            {
                Content = map;
            });
        }
    }

}
