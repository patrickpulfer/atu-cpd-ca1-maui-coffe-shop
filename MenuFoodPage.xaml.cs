using CoffeeShop.ViewModel;

namespace CoffeeShop;

public partial class MenuFoodPage : ContentPage
{
    public MenuFoodPage(MenuViewModel menu_vm)
    {
        InitializeComponent();
        BindingContext = menu_vm;

    }
}