using SteamStoreAPI.Models;
using SteamWishlistApp.Models;
using SteamWishlistApp.ViewModel;
using SteamWishlistApp.ViewModels;
using System.Collections.ObjectModel;

namespace SteamWishlistApp.Views;

public partial class FriendPage : ContentPage
{
	public FriendPage(FriendViewModel viewModel) {
		InitializeComponent();

        Friend friend = new Friend { Name = "Dang" };

        friend.Games.Add(new SteamApp { Title = "Testing Game 1" });
        friend.Games.Add(new SteamApp { Title = "Testing Game - The Sequel"});

        viewModel.Games = new ObservableCollection<SteamApp>(friend.Games);

        BindingContext = viewModel;

    }
}