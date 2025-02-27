using SteamStoreAPI.Models;
using SteamWishlistApp.ViewModels;
using System.Diagnostics;
using System.Globalization;

namespace SteamWishlistApp.Controls;

public partial class GameControl : ContentView
{

    public static readonly BindableProperty GameProperty = BindableProperty.Create(nameof(Game), typeof(SteamApp), typeof(GameControl));
    public SteamApp Game {
        get => (SteamApp)GetValue(GameControl.GameProperty);
        set => SetValue(GameControl.GameProperty, value);
    }

    public GameControl()
	{
		InitializeComponent();
	}

    private async void Title_Tapped(object sender, TappedEventArgs e) {
        try {
            Uri uri = new Uri($"https://store.steampowered.com/app/{Game.AppId}/");
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        } catch (Exception ex) {
            Trace.WriteLine(ex);
        }
    }

    private void Button_Clicked(object sender, EventArgs e) {

        if (sender is Button button && button.CommandParameter is FriendViewModel vm) {
            Trace.WriteLine(vm);
            vm.Friend.Games.Remove(Game);
        }

    }
}