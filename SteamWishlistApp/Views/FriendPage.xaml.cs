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

    private async void AddGame_Clicked(object sender, EventArgs e) {
        var app = await MauiProgram.DataClient.GetSteamApp(1245620); // Elden ring
        var app2 = await MauiProgram.DataClient.GetSteamApp(516750); // My summer car
        ((FriendViewModel)BindingContext).Friend.Games.Add(app);
        ((FriendViewModel)BindingContext).Friend.Games.Add(app2);
        Trace.WriteLine("Add Game button clicked.");
    }
}