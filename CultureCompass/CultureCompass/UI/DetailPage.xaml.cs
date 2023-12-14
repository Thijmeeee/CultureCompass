namespace CultureCompass.UI;

public partial class DetailPage : ContentPage
{
	public DetailPage()
	{ 
		InitializeComponent();
	}

    public async void OnStartClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}