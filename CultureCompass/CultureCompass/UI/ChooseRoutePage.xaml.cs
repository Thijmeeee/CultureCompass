using CultureCompass.Information;

namespace CultureCompass.UI;

public partial class ChooseRoutePage : ContentPage
{

	public ChooseRoutePage()
	{
		InitializeComponent();
    }

    private void OnRouteTapped(object sender, TappedEventArgs e)
    {
		Route route = e.Parameter as Route;

        Navigation.PushAsync(new NavigationPage(route));
    }
}