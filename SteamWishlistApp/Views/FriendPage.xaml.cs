using SteamStoreAPI.Models;
using SteamWishlistApp.Controls;
using SteamWishlistApp.Models;
using SteamWishlistApp.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace SteamWishlistApp.Views;

public partial class FriendPage : ContentPage
{

	public FriendPage(FriendViewModel viewModel) {
		InitializeComponent();

        BindingContext = viewModel;

    }

    private async void AddGame_Clicked(object sender, EventArgs e) {
        string input = UrlEntry.Text ?? "";
        string pattern = @"(\d+)";
        Match match = Regex.Match(input, pattern);
        string firstMatch = match.ToString();
        if (!String.IsNullOrEmpty(firstMatch) && int.TryParse(firstMatch, out var id)) {
            var app = await MauiProgram.DataClient.GetSteamApp(id);

            if (app == null) return;

            ((FriendViewModel)BindingContext).Friend.Games.Add(app);

            Trace.WriteLine($"Added game: {app.Title}.");

            UrlEntry.Text = string.Empty;
        }
    }

    private async void RemoveFriend_Tapped(object sender, TappedEventArgs e) {
        await Shell.Current.GoToAsync("///" + nameof(MainPage), false);
        TopBar.Friends.Remove(((FriendViewModel)BindingContext).Friend);
    }
}