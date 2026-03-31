using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class Product1Controller : Controller
    {
        private static List<dynamic> products = new List<dynamic>();

        [HttpGet]
        [Route("product1/index")]
        public IActionResult Index()
        {
            ViewBag.Products = products;
            return View();
        }
        [HttpPost]
        [Route("product1/index")]
        public IActionResult Index(string name, double price, int quantity)
        {
            // add product to list
            products.Add(new
            {
                Name = name,
                Price = price,
                Quantity = quantity
            });

            ViewBag.Products = products;
            return View();
        }
    }
}

