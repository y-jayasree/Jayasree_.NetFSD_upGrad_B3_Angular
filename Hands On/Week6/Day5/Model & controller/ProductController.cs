using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>()
        {
            new Product{ProductId=1,ProductName="AC",Price = 50000, Category = "Electronics"},
            new Product{ProductId=2,ProductName="Table",Price = 2000, Category = "Furniture"}
        };
        public IActionResult Index()
        {
            return View(products);
        }
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                products.Add(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                var product = products.FirstOrDefault(x => x.ProductId == p.ProductId);
                if (product != null)
                {
                    product.ProductName = p.ProductName;
                    product.Price = p.Price;
                    product.Category = p.Category;
                }
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            var product = products.FirstOrDefault(x => x.ProductId == id);
            if (product != null)
                products.Remove(product);

            return RedirectToAction("Index");
        }
    }
}
