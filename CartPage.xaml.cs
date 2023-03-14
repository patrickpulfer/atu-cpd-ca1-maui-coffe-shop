using CoffeeShop.ViewModel;

namespace CoffeeShop;

public partial class CartPage : ContentPage
{
	public CartPage(CartViewModel cart_vm)
	{
		InitializeComponent();
        BindingContext = cart_vm;
	}
}