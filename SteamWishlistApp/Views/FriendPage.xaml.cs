using SteamStoreAPI.Models;
using SteamWishlistApp.Models;
using SteamWishlistApp.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SteamWishlistApp.Views;

public partial class FriendPage : ContentPage
{

	public FriendPage(FriendViewModel viewModel) {
		InitializeComponent();

        BindingContext = viewModel;

    }

    private void AddGame_Clicked(object sender, EventArgs e) {
        // TODO: Add game to both friend's list and BindingContext list, or re-create list from friend's list
        ((FriendViewModel)BindingContext).Friend.Games.Add(new SteamApp { Title = "Woah it's a game"});
        Trace.WriteLine("Add Game button clicked.");
    }
}