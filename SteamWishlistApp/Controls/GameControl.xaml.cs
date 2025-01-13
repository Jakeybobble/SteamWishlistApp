namespace SteamWishlistApp.Controls;

public partial class GameControl : ContentView
{

    public static readonly BindableProperty GameTitleProperty = BindableProperty.Create(nameof(GameTitle), typeof(string), typeof(GameControl), string.Empty);
    public string GameTitle {
        get => (string)GetValue(GameControl.GameTitleProperty);
        set => SetValue(GameControl.GameTitleProperty, value);
    }

    public GameControl()
	{
		InitializeComponent();
	}
}