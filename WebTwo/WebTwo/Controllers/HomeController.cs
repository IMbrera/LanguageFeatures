using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebTwo.Models;

namespace WebTwo.Controllers
{
    public class HomeController : Controller
    {
        bool filterByPrice(Product p)
        {
            return (p.Price ?? 0) >= 20;
        }
        public ViewResult Index()
        {
            ShopingCart cart = new ShopingCart { Products = Product.GetProducts() };
            Product[] productArray =
            {
                new Product {Name = "Kayak", Price = 275M},
                new Product {Name = "LifeJacket", Price = 50M},
                 new Product {Name = "Dick", Price = 19.5M},
                new Product {Name = "Tits", Price = 34.95M}
            };
            Func<Product, bool> nameFilter = delegate (Product prod)
            {
                return prod?.Name?[0] == 'D';
            };
            decimal priceFilterTotal = productArray.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices();
            decimal nameFilterTotal = productArray.Filter(p => p?.Name?[0] == 'D').TotalPrices();
          //  decimal cartTotal = cart.TotalPrices();
            return View ("Index", new string[] {
                $"Price Total: {priceFilterTotal:C2}",
                $"Name Total: {nameFilterTotal:C2}"});
        }

    }
}

//    decimal arrayTotal = productArray.FilterByPrice(20).TotalPrices();
//      return View("Index", new string[] { $"Array Total: {arrayTotal:C2}" });
/*
Dictionary<string, Product> products = new Dictionary<string, Product>
          {
   ["Kayak"] = new Product {Name = "Kayak", Price = 375M },
   ["Lifejacket"]= new Product { Name = "Lifejacket", Price = 50M}
};
return View("Index", products.Keys);
*/
// return View("Index", new string[] { "Bob", "Joe", "Alice" });
#region
/*
string[] names = new string[3];
names[0] = "Bob";
names[1] = "Joe";
names[2] = "Alice";
return View("Index", names);
*/
#endregion
#region
/*
List<string> results = new List<string>();
foreach(Product p in Product.GetProducts())
{
    string name = p?.Name ?? "<No Name>";
    decimal? price = p?.Price ?? 0;
    string relatedName = p?.Related?.Name ?? "<None>";
    results.Add($"Name: {name}, Price: {price}, Related: {relatedName}");
}
            return View(results);
            */
#endregion
