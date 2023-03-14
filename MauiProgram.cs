using CoffeeShop.ViewModel;
using Microsoft.Extensions.Logging;
using CoffeeShop.Services;

namespace CoffeeShop;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Views
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<CartPage>();
        builder.Services.AddSingleton<OrdersPage>();
        builder.Services.AddSingleton<MenuHotPage>();
        builder.Services.AddSingleton<MenuColdPage>();
        builder.Services.AddSingleton<MenuFoodPage>();

        // ViewModels
        builder.Services.AddSingleton<UserProfileViewModel>();
        builder.Services.AddSingleton<MenuViewModel>();     
        builder.Services.AddSingleton<CartViewModel>();
        builder.Services.AddSingleton<OrdersPageViewModel>();


        Global.CurrentSessionID = (int)DateTime.Now.ToFileTimeUtc() * -1;

        //System.Diagnostics.Debug.Write("Pat: Timestamp is ");
        //System.Diagnostics.Debug.WriteLine(Global.CurrentSessionID);


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
