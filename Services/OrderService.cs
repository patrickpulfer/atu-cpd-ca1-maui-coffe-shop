using CoffeeShop.Models;
using CoffeeShop.ViewModel;


namespace CoffeeShop.Services
{
    class OrderService
    {       
        List<List<object>> main_order = new List<List<object>>();
        List<object> order_list = new List<object>();


        string Date = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        int Session = Global.CurrentSessionID;


        OrderService() {

        }


    }
}

