namespace SteamWishlistApp.Views;

public partial class BasePage : ContentPage
{

	/// <summary>
	/// "Wrapper" page which contains the top bar
	/// </summary>
	public BasePage()
	{
		InitializeComponent();
	}

	// TODO: Get rid of the animation!!!!!!

    private async void Home_Clicked(object sender, EventArgs e) {
		await Shell.Current.GoToAsync("///" + nameof(MainPage), false);
    }

	private async void Friend_Clicked(object sender, EventArgs e) {
		// TODO: This should be an ICommand in the ViewModel in the future
		await Shell.Current.GoToAsync("/" + nameof(FriendPage), false);

	}
}