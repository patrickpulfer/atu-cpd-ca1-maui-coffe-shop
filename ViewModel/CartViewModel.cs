using CoffeeShop.Models;
using CoffeeShop.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;


namespace CoffeeShop.ViewModel
{
    public partial class CartViewModel : ObservableObject
    {
        static MenuService menuService = new MenuService();

        [ObservableProperty]
        private static double totalPrice = 0;

        [ObservableProperty]
        private string ordered = "";
        
        // New List
        private List<CartModel2> cart2 { get; set; }


        private List<CartModel> cart { get; set; }
        private List<Checkout> checkout_cart { get; set; }

        public Command Order { get; set; }
        public Command Refresh { get; set; }

        public ObservableCollection<Checkout> Checkout_list { get; set; } = new ObservableCollection<Checkout>();




        public CartViewModel(){

            Order = new Command<string>(OrderMethod);
            Refresh = new Command<string>(RefreshMethod);

            cart = CartService.GetCart();
            checkout_cart = CartService.GetCheckout();

           

            MatchCartToMenu();
            ExtendCheckoutList();

        }

        public double GetTotalPrice()
        {
            return this.TotalPrice;
        }


        private void RefreshMethod(string obj) {
            Checkout_list.Clear();
            checkout_cart.Clear();
            TotalPrice = 0;

            cart = CartService.GetCart();
            checkout_cart = CartService.GetCheckout();

            MatchCartToMenu();
            ExtendCheckoutList();
        }


        private void OrderMethod(string obj)
        {

            CartService.Prepare_Order();


            Checkout_list.Clear();
            checkout_cart.Clear();
            cart.Clear();

            cart = CartService.GetCart();
            checkout_cart = CartService.GetCheckout();

            MatchCartToMenu();
            ExtendCheckoutList();

            Ordered = "Ordered, please pay at the till!";
            
        }




        private void ExtendCheckoutList()
        {

            foreach (var item in checkout_cart)
            {

                Checkout_list.Add(new Checkout { ProductID = item.ProductID, Name = item.Name, Image = item.Image, Price = item.Price, Quantity = item.Quantity });
            }
        }


        public void MatchCartToMenu()
        {
            var menu_items = menuService.GetMenu();

            foreach (CartModel element in cart)
            {
                System.Diagnostics.Debug.Write("1st Foreach: ");
                System.Diagnostics.Debug.WriteLine(element.ProductID);

                foreach (var item in menu_items) { 
                if (item.ProductID == element.ProductID)
                    {
                        System.Diagnostics.Debug.Write("2nd Foreach. Found: ");
                        System.Diagnostics.Debug.WriteLine(item.ProductID);

                        checkout_cart.Add(new Checkout{ProductID = element.ProductID, Name=item.Name, Image = item.Image, Price= item.Price, Quantity=element.Quantity});

                        TotalPrice = TotalPrice + item.Price;
                        break;
                    }
                }
            }
            System.Diagnostics.Debug.Write("Added: ");
            System.Diagnostics.Debug.WriteLine(checkout_cart.Count);
        }
    
    }

    public partial class CheckoutViewModel : ObservableObject {}


}
