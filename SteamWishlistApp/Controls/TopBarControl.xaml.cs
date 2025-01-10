using SteamStoreAPI.Models;
using SteamWishlistApp.Models;
using SteamWishlistApp.ViewModels;
using SteamWishlistApp.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SteamWishlistApp.Controls;

public partial class TopBarControl : ContentView
{

    private static ObservableCollection<Friend> _friends = new ObservableCollection<Friend>();
    public ObservableCollection<Friend> Friends {
        get => _friends;
        set {
            _friends = value;
            OnPropertyChanged(nameof(Friends));
        }
    }

    public TopBarControl()
	{
		InitializeComponent();
        BindingContext = this;
	}

    private async void Friend_Tapped(object sender, TappedEventArgs e) {
        Trace.WriteLine("Friend button has been pressed.");
        await Shell.Current.GoToAsync("/" + nameof(FriendPage), new Dictionary<string, object> {
            { "Friend", new Friend { Name = "Hecker", Games = new List<SteamApp> { new SteamApp { Title = "Hecker Game"} } } }
        });
    }

    private async void Home_Tapped(object sender, TappedEventArgs e) {
        Trace.WriteLine("Home button has been pressed.");
        await Shell.Current.GoToAsync("///" + nameof(MainPage), false);
    }

    private void Plus_Tapped(object sender, TappedEventArgs e) {
        Trace.WriteLine("Adding new friend.");
        Friends.Add(new Friend { Name = "Tomki" });
    }
}