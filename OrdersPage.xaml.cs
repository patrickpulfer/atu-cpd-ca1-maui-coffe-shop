using CoffeeShop.ViewModel;

namespace CoffeeShop;

public partial class OrdersPage : ContentPage
{
	public OrdersPage(OrdersPageViewModel orders_vm)
	{
		InitializeComponent();
		BindingContext = orders_vm;
	}
}