using CultureCompass.Pages;

namespace CultureCompass
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnStartClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MapPage());
        }
    }

}
