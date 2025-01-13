using SteamStoreAPI.Models;
using System.Diagnostics;

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

}