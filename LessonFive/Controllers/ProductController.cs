using LessonFive.Models;
using Microsoft.AspNetCore.Mvc;

namespace LessonFive.Controllers
{
    public class ProductController :Controller
    {

        private static List<Product>? _products = new List<Product>()
            {
                new Product(){Id=1, Name="Product1", Quantity=1, Price=1,},
                new Product(){Id=2, Name="Product2", Quantity=2, Price=2,},
                new Product(){Id=3, Name="Product3", Quantity=3, Price=3,},
                new Product(){Id=4, Name="Product4", Quantity=4, Price=4,},
                new Product(){Id=5, Name="Product5", Quantity=5, Price=5,},
                new Product(){Id=6, Name="Product6", Quantity=6, Price=6,},
                new Product(){Id=7, Name="Product7", Quantity=7, Price=7,},
                new Product(){Id=8, Name="Product8", Quantity=8, Price=8,},
                new Product(){Id=9, Name="Product9", Quantity=9, Price=9,},
                new Product(){Id=10, Name="Product10", Quantity=10, Price=10,}
            };



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                product.Id = _products!.Count + 1;
               _products.Add(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        [HttpGet]
        public IActionResult Remove()
        {
            return View(_products);
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
            return RedirectToAction("Remove");
        }

        public IActionResult GetAll()
        {
            return View(_products);
        }


        [HttpGet]
        public IActionResult GetProductById(int id)
        {
            if (id != 0)
            {
                var products = _products!.Where(p => p.Id == id).ToList();
                return PartialView("_ProductListPartial", products);
            }
            return View();
        }




        [HttpGet]
        public IActionResult GetProductsByPrice(double price)
        {
            if (price != 0)
            {
                var products = _products.Where(p => p.Price == price).ToList();
                return PartialView("_ProductListPartial", products);
            }
            return View();
        }

    }
}
