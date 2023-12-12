using Map = Microsoft.Maui.Controls.Maps.Map;

namespace CultureCompass
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Map map = new Map();
            Content = map;
        }
    }

}
