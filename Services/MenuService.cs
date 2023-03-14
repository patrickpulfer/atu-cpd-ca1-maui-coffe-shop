using CoffeeShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Services
{
    public class MenuService
    {

        List<MenuModel> menuData = new() {

            new MenuModel(){ Name = "Coffee", Description = "Roasted Coffee with origin South and Central America", Category = "hot", Image = "product_coffee.png", Price = 2.20, ProductID = "hot_coffee" },
            new MenuModel(){ Name = "Hot Chocolate", Description = "Indulge in a homemade hot chocolate", Category = "hot", Image = "product_chocolate.png", Price = 2.20, ProductID = "hot_chocolate" },
            new MenuModel(){ Name = "Tea", Description = "Barry's Tea is freshly blended with the same high quality leaves as Gold Blend.", Category = "hot", Image = "product_tea.png", Price = 2.20, ProductID = "hot_tea" },
            new MenuModel(){ Name = "Latte", Description = "Coffee and milk go together like bread and butter.", Category = "hot", Image = "product_latte.png", Price = 2.20, ProductID = "hot_latte" },

            new MenuModel(){ Name = "Water", Description = "Bottled Wild Irish Natural Mineral Water", Category = "cold", Image = "product_water.png", Price = 2.20, ProductID = "cold_water" },
            new MenuModel(){ Name = "Sparkling Water", Description = "Bottled Wild Irish Sparkling Water", Category = "cold", Image = "product_sparkling.png", Price = 2.20, ProductID = "cold_s_water" },
            new MenuModel(){ Name = "Fanta", Description = "Bright, bubbly, instantly refreshing and great tasting.", Category = "cold", Image = "product_fanta.png", Price = 2.20, ProductID = "cold_fanta" },
            new MenuModel(){ Name = "Coca Cola", Description = "No description needed!", Category = "cold", Image = "product_cola.png", Price = 2.20, ProductID = "cold_cola" },

            new MenuModel(){ Name = "Healthy Eggs", Description = "Healthy Egg Breakfast to start your day", Category = "food", Image = "product_eggs.png", Price = 8, ProductID = "food_eggs" },
            new MenuModel(){ Name = "Donut", Description = "Our delicious glazed ring donut dipped in chocolate fondant icing", Category = "food", Image = "product_donut.png", Price = 2.20, ProductID = "food_donut" },
            new MenuModel(){ Name = "Blueberry pie", Description = "Homemade fresh pie.", Category = "food", Image = "product_pie.png", Price = 2.20, ProductID = "food_pie" },
            new MenuModel(){ Name = "Cookies", Description = "These fudgy chocolate cookies made with cocoa powder and chocolate chips are a dream for chocolate. ", Category = "food", Image = "product_cookie.png", Price = 2.20, ProductID = "food_cookie" }
        };

        public List<MenuModel> GetMenu()
        {
            return menuData;
        }

        public MenuService() { }

    }
}