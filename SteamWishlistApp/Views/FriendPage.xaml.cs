using SteamWishlistApp.ViewModel;
using SteamWishlistApp.ViewModels;

namespace SteamWishlistApp.Views;

public partial class FriendPage : ContentPage
{
	public FriendPage(FriendViewModel viewModel) {
		InitializeComponent();
		BindingContext = viewModel;

	}
}