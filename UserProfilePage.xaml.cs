using CoffeeShop.ViewModel;

namespace CoffeeShop;

public partial class UserProfilePage : ContentPage
{
	public UserProfilePage()
	{
		InitializeComponent();
		BindingContext = new UserProfileViewModel();
	}
}