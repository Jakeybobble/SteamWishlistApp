using SteamWishlistApp.Models;
using SteamWishlistApp.ViewModels;
using SteamWishlistApp.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SteamWishlistApp.Controls;

public partial class TopBarContent : ContentView
{

    private static ObservableCollection<Friend> _friends = new ObservableCollection<Friend>();
    public ObservableCollection<Friend> Friends {
        get => _friends;
        set {
            _friends = value;
            OnPropertyChanged(nameof(Friends));
        }
    }

    public TopBarContent()
	{
		InitializeComponent();
        BindingContext = this;
	}

    private async void Friend_Tapped(object sender, TappedEventArgs e) {
        Trace.WriteLine("Friend button has been pressed.");
        await Shell.Current.GoToAsync("/" + nameof(FriendPage), false);
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