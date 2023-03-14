using CoffeeShop.Models;
using Microsoft.Maui.Controls;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Xml.Linq;

namespace CoffeeShop.Services
{
    public static class CartService
    {
        static MenuService menuService = new MenuService();

        static List<CartModel> cartData = new() { };

        static List<Checkout> checkoutData = new(){ };

        static List<CartModel2> cartData2 = new();

        static string jsonString;

        static double TotalPrice;
        

        public static List<CartModel> GetCart()
        {
            System.Diagnostics.Debug.Write("CartService Returning:");
            System.Diagnostics.Debug.WriteLine(cartData);
            return cartData;

        }

        public static List<CartModel2> GetCart2()
        {
            System.Diagnostics.Debug.Write("CartService Returning:");
            System.Diagnostics.Debug.WriteLine(cartData2);
            return cartData2;

        }

        public static List<Checkout> GetCheckout()
        {
            return checkoutData;
        }

        public static void InsertToCart(string ProductID)
        {
            bool found_element_inSearch = false;
            //TotalPrice = 0;
            bool found_element_inSearch2 = false;
            var menu_items = menuService.GetMenu();

            //System.Diagnostics.Debug.Write("Searched for ProductID:");
            //System.Diagnostics.Debug.WriteLine(ProductID);

            //System.Diagnostics.Debug.WriteLine(cartData);

            
            foreach (CartModel element in cartData) {

                //System.Diagnostics.Debug.Write("Searched trough quantity: ");
                //System.Diagnostics.Debug.WriteLine(cartData.Count);
                //System.Diagnostics.Debug.Write("Product ID: ");
                //System.Diagnostics.Debug.WriteLine(element.ProductID);
                //System.Diagnostics.Debug.WriteLine("---------");


                if (element.ProductID == ProductID) {

                    element.Quantity = + 1;
                    found_element_inSearch = true;
                    //System.Diagnostics.Debug.Write("Found:");
                    //System.Diagnostics.Debug.WriteLine(element);
                    break;
                }
            }

            if (found_element_inSearch == false)
            {
                cartData.Add(new CartModel() { ProductID = ProductID, Quantity = 1 });
                //cartData2.Add(new CartModel2() { ProductID = ProductID, ProductName = })

                //System.Diagnostics.Debug.Write("Adding Product ID: ");
                //System.Diagnostics.Debug.WriteLine(ProductID);
                //System.Diagnostics.Debug.Write("Current Count: ");
                //System.Diagnostics.Debug.WriteLine(cartData.Count);
                //System.Diagnostics.Debug.WriteLine("---------");
            }

            /* New For Each */

            foreach (CartModel2 element in cartData2)
            {

                if (element.ProductID == ProductID)
                {
                    element.ProductQuantity = +1;
                    found_element_inSearch2 = true;
                    System.Diagnostics.Debug.Write("Found:");
                    System.Diagnostics.Debug.WriteLine(element);
                    break;
                }
            }

            if (found_element_inSearch2 == false)
            {

                foreach (MenuModel menu_item in menu_items) {
                    if (menu_item.ProductID == ProductID) {
                        cartData2.Add(new CartModel2 { ProductID = ProductID, ProductQuantity = 1, ProductName = menu_item.Name, ProductImage = menu_item.Image, ProductPrice = menu_item.Price});
                        TotalPrice += menu_item.Price;


                        System.Diagnostics.Debug.Write("Adding Product ID: ");
                        System.Diagnostics.Debug.WriteLine(ProductID);

                        System.Diagnostics.Debug.Write("Price: ");
                        System.Diagnostics.Debug.WriteLine(menu_item.Price);

                        System.Diagnostics.Debug.Write("Total Price: ");
                        System.Diagnostics.Debug.WriteLine(TotalPrice);
                        break;
                    }
                
                }

            }

            /* End of New For Each */

        }

        public static void Prepare_Order()
        {
            string Date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            int Session = Global.CurrentSessionID;

            var Name = Preferences.Get("userName", "");
            var Telephone = Preferences.Get("userPhone", "");

            List<object> orderDetails = new()
            {
                new OrderModel(){
                    Id = Session,
                    Date = Date,
                    Name = Name,
                    Telephone = Telephone,
                    Total = TotalPrice
                }

            };
            //orderDetails = new(menu_items);
            orderDetails.Add(cartData2);

            jsonString = JsonSerializer.Serialize(orderDetails);
            System.Diagnostics.Debug.Write("Order Json: ");
            System.Diagnostics.Debug.WriteLine(jsonString);

            SaveOrder(jsonString);


        }

        private static async Task SaveOrder(string jsonString) {
            var path = FileSystem.Current.AppDataDirectory;
            var fullpath = Path.Combine(path, "Orders.json");


            File.WriteAllLines(fullpath, jsonString.Split('\n'));

            await Shell.Current.DisplayAlert("Saved!", "Order has been saved to file!", "Ok");

        }

    }

}