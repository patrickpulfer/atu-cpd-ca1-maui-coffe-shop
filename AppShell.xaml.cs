namespace CoffeeShop;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
        Routing.RegisterRoute(nameof(UserProfilePage), typeof(UserProfilePage));
        
        Routing.RegisterRoute(nameof(CartPage), typeof(CartPage));
        Routing.RegisterRoute(nameof(OrdersPage), typeof(OrdersPage));

        Routing.RegisterRoute(nameof(MenuHotPage), typeof(MenuHotPage));
        Routing.RegisterRoute(nameof(MenuColdPage), typeof(MenuColdPage));
        Routing.RegisterRoute(nameof(MenuFoodPage), typeof(MenuFoodPage));
    }
}
