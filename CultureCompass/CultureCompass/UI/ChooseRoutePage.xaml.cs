using CultureCompass.Information;

namespace CultureCompass.UI;

public partial class ChooseRoutePage : ContentPage
{

	public ChooseRoutePage()
	{
		InitializeComponent();
        StartRouteButton.IsEnabled = false;
    }

	public void OnRouteStartedClicked(object sender, EventArgs e)
	{
		Navigation.PushAsync(new NavigationPage(collectionView.SelectedItem));
	}

    private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		if (e.CurrentSelection == null)
		{
			StartRouteButton.IsEnabled = false;
		}
		else StartRouteButton.IsEnabled = true;
    }
}