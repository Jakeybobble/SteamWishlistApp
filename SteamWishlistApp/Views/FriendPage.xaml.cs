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
        ((FriendViewModel)BindingContext).Friend.Games.Add(app);
        Trace.WriteLine("Add Game button clicked.");
    }
}