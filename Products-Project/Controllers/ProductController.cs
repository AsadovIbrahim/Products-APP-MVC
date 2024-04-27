using Microsoft.AspNetCore.Mvc;
using Products_Project.Models;
using System.Text.Json;
using static Products_Project.Models.JsonHandler;

namespace Products_Project.Controllers
{
    public class ProductController : Controller
    {

        public List<Product> Products { get; set; } = new List<Product>();
        public ProductController()
        {
            Products = ReadData<List<Product>>("products")!;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                if (Products.Exists(p => p.Id == product.Id))
                {
                    return View(product);

                }
                Products.Add(product);
                WriteData(Products, "products");
                return RedirectToAction("GetAllProducts");
            }
            return View(product);
        }

        [HttpPost]
        public IActionResult GetProductById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                return View(product);
            }
            return View();
        }
        [HttpGet]
        public IActionResult GetProductById()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetProductByPrice(float price)
        {
            if (ModelState.IsValid)
            {
                var product = Products.Where(p => p.Price == price).ToList();
                if (product != null)
                {
                    return View(product);
                }
            }
            return View();
        }

        [HttpGet]
        public IActionResult GetProductByPrice()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RemoveProduct(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Products.Remove(product);
                WriteData(Products, "products");
            }
            return RedirectToAction("GetAllProducts");
        }

        [HttpGet]
        public IActionResult RemoveProduct()
        {
            return View();
        }


        public IActionResult GetAllProducts()
        {
            return View(Products);
        }

    }
}
