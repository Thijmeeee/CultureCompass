namespace CultureCompass.UI;

public partial class ChooseRoutePage : ContentPage
{
	public ChooseRoutePage()
	{
		InitializeComponent();
		InitializeCollectionView();
	}


	public void InitializeCollectionView()
	{
		collectionView.ItemsSource = new List<string>
		{
			"kip",
			"test1",
			"test2",
            "kip",
            "test1",
            "test2",
            "kip",
            "test1",
            "test2",
            "test3"
        };

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