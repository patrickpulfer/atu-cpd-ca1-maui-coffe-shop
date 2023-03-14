using CoffeeShop.Models;
using CoffeeShop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;


namespace CoffeeShop.ViewModel
{
    public partial class MenuViewModel : ObservableObject
    {
        static MenuService menuService = new MenuService();
               
        private List<CartModel> cart { get; set; }

        public Command AddToCart { get; set; }


        public ObservableCollection<MenuModel> HotMenuCollection { get; set; } = new ObservableCollection<MenuModel>();
        public ObservableCollection<MenuModel> ColdMenuCollection { get; set; } = new ObservableCollection<MenuModel>();
        public ObservableCollection<MenuModel> FoodMenuCollection { get; set; } = new ObservableCollection<MenuModel>();


        public MenuViewModel()
        {
            GetHotMenu();
            GetColdMenu();
            GetFoodMenu();

            AddToCart = new Command<string>(AddToCartMethod);

            cart = CartService.GetCart();

            System.Diagnostics.Debug.Write("Cart at MenuViewModel is: ");
            System.Diagnostics.Debug.WriteLine(cart);
        }

        //[RelayCommand]
        private void AddToCartMethod(string productid)
        {
            System.Diagnostics.Debug.WriteLine("AddToCartMethod method being called");
            System.Diagnostics.Debug.WriteLine(productid);
            System.Diagnostics.Debug.Write("Pat: Timestamp is ");
            System.Diagnostics.Debug.WriteLine(Global.CurrentSessionID);

            CartService.InsertToCart(productid);
        }


        private void GetHotMenu()
        {
            var menu_items = menuService.GetMenu();
            foreach (var item in menu_items)
            {
                if (item.Category == "hot")
                {
                    HotMenuCollection.Add(item);
                    System.Diagnostics.Debug.WriteLine(item.Name);
                }

            }
        }

        private void GetColdMenu()
        {
            var menu_items = menuService.GetMenu();
            foreach (var item in menu_items)
            {
                if (item.Category == "cold")
                {
                    ColdMenuCollection.Add(item);
                }

            }
        }

        private void GetFoodMenu()
        {
            var menu_items = menuService.GetMenu();
            foreach (var item in menu_items)
            {
                if (item.Category == "food")
                {
                    FoodMenuCollection.Add(item);
                }

            }
        }
    }
}
