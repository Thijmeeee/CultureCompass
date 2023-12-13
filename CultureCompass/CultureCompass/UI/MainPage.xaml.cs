using CultureCompass.UI;

namespace CultureCompass.UI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnStartClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationPage());
        }
    }
}
