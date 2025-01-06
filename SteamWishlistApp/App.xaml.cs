using SteamWishlistApp.Views;

namespace SteamWishlistApp {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            MainPage = new AppShell();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(FriendPage), typeof(FriendPage));
        }
    }
}
