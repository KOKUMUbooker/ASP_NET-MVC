using p.SessionsDemo.Models;
using p.SessionsDemo.Services;
using Microsoft.AspNetCore.Mvc;
namespace p.SessionsDemo.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        // Inject ProductService via constructor
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        // Show all products
        public IActionResult Index()
        {
            List<Product> products = _productService.GetAllProducts();
            return View(products);
        }

        // Show details of a product by id
        public IActionResult Details(int id)
        {
            Product? product = _productService.GetProductById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}