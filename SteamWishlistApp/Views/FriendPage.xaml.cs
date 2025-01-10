using SteamStoreAPI.Models;
using SteamWishlistApp.Models;
using SteamWishlistApp.ViewModel;
using SteamWishlistApp.ViewModels;
using System.Collections.ObjectModel;

namespace SteamWishlistApp.Views;

public partial class FriendPage : ContentPage
{

    //private Friend friend = new Friend { Name = "Test Friend" };

	public FriendPage(FriendViewModel viewModel) {
		InitializeComponent();

        BindingContext = viewModel;

    }

    private void AddGame_Clicked(object sender, EventArgs e) {
        // TODO: Add game to both friend's list and BindingContext list, or re-create list from friend's list
    }
}