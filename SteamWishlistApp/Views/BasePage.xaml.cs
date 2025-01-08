using SteamWishlistApp.Models;
using SteamWishlistApp.ViewModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace SteamWishlistApp.Views;

public partial class BasePage : ContentPage {

    private BaseViewModel viewModel;

    /// <summary>
    /// "Wrapper" page which contains the top bar
    /// </summary>
    public BasePage(BaseViewModel baseViewModel) {
        InitializeComponent();
        viewModel = baseViewModel;
        BindingContext = viewModel;
    }

    private async void Home_Clicked(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("///" + nameof(MainPage), false);
    }

    private async void Friend_Clicked(object sender, EventArgs e) {
        await Shell.Current.GoToAsync("/" + nameof(FriendPage), false);

    }

    private void Plus_Tapped(object sender, TappedEventArgs e) {
        viewModel.Friends.Add(new Friend { Name = "Tomki" });
    }
}