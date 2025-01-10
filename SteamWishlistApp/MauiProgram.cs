using Microsoft.Extensions.Logging;
using SteamWishlistApp.Controls;
using SteamWishlistApp.ViewModel;
using SteamWishlistApp.ViewModels;
using SteamWishlistApp.Views;

namespace SteamWishlistApp {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<BasePage>();
            builder.Services.AddSingleton<BaseViewModel>();

            builder.Services.AddSingleton<TopBarControl>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<FriendPage>();
            builder.Services.AddTransient<FriendViewModel>();

            return builder.Build();
        }
    }
}
