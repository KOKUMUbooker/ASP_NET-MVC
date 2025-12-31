using p.SessionsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using p.SessionsDemo.Helpers;
using p.SessionsDemo.Services;
namespace p.SessionsDemo.Controllers
{
    public class CartController : Controller
    {
        private const string SessionCartKey = "CartSession";
        private readonly ProductService _productService;

        public CartController(ProductService productService)
        {
            _productService = productService;
        }

        // Show cart items
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(SessionCartKey) ?? new List<CartItem>();
            return View(cart);
        }

        // Add product to cart by productId
        [HttpPost]
        public IActionResult AddToCart(int productId)
        {
            var product = _productService.GetProductById(productId);
            if (product == null)
                return NotFound();

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(SessionCartKey) ?? new List<CartItem>();

            var existingItem = cart.FirstOrDefault(c => c.ProductId == product.Id);
            if (existingItem == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    Quantity = 1,
                    ImageUrl = product.ImageUrl
                });
            }
            else
            {
                existingItem.Quantity++;
            }

            HttpContext.Session.SetObjectAsJson(SessionCartKey, cart);

            // Store success message in TempData
            TempData["CartSuccess"] = $"{product.Name} has been added to your cart!";

            // Redirect back to product details page to stay on the same page
            return RedirectToAction("Details", "Product", new { id = productId });
        }

        // Remove product from cart
        public IActionResult Remove(int productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(SessionCartKey) ?? new List<CartItem>();

            var item = cart.FirstOrDefault(c => c.ProductId == productId);
            if (item != null)
            {
                cart.Remove(item);
                HttpContext.Session.SetObjectAsJson(SessionCartKey, cart);
            }

            return RedirectToAction("Index");
        }

        // Clear all items in cart
        public IActionResult Clear()
        {
            HttpContext.Session.Remove(SessionCartKey);
            return RedirectToAction("Index");
        }
    }
}