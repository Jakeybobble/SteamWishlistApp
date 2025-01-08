using Microsoft.Extensions.Logging;
using SteamWishlistApp.ViewModel;
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
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<FriendPage>();

            return builder.Build();
        }
    }
}
