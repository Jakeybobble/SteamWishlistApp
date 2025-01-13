using SteamStoreAPI.Models;
using SteamWishlistApp.Models;
using SteamWishlistApp.ViewModels;
using SteamWishlistApp.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Mopups.Services;
using System.Threading.Tasks;
namespace SteamWishlistApp.Controls;

public partial class TopBarControl : ContentView {

    private static ObservableCollection<Friend> _friends = new ObservableCollection<Friend>();
    public ObservableCollection<Friend> Friends {
        get => _friends;
        set {
            _friends = value;
            OnPropertyChanged(nameof(Friends));
        }
    }

    public TopBarControl() {
        InitializeComponent();
        BindingContext = this;
    }

    private async void Friend_Tapped(object sender, TappedEventArgs e) {
        Trace.WriteLine("Friend button has been pressed.");

        if (sender is VisualElement visualElement && visualElement.BindingContext is Friend friend) {
            await Shell.Current.GoToAsync("/" + nameof(FriendPage), new Dictionary<string, object> {
                { "Friend", friend }
            });
        }
    }

    private async void Home_Tapped(object sender, TappedEventArgs e) {
        Trace.WriteLine("Home button has been pressed.");
        await Shell.Current.GoToAsync("///" + nameof(MainPage), false);
    }

    private async void Plus_Tapped(object sender, TappedEventArgs e) {
        Trace.WriteLine("Adding new friend.");

        var tcs = new TaskCompletionSource<string>();
        await MopupService.Instance.PushAsync(new AddFriendPopUp(tcs));

        string result = await tcs.Task;
        if (!string.IsNullOrEmpty(result))
        {
            Trace.WriteLine($"Adding new friend: {result}");
            Friends.Add(new Friend { Name = result });
        }
        //Friends.Add(new Friend { Name = "Tomki" });
    }
}