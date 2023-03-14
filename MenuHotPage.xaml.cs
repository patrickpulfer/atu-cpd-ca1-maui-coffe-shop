using CoffeeShop.ViewModel;

namespace CoffeeShop;

public partial class MenuHotPage : ContentPage
{
    public MenuHotPage(MenuViewModel menu_vm)
    {
        InitializeComponent();
        BindingContext = menu_vm;

    }
}