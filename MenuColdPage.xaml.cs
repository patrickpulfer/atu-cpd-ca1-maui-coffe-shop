using CoffeeShop.ViewModel;

namespace CoffeeShop;

public partial class MenuColdPage : ContentPage
{
    public MenuColdPage(MenuViewModel menu_vm)
    {
        InitializeComponent();
        BindingContext = menu_vm;

    }
}