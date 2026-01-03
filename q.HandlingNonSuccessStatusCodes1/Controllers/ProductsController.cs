using Microsoft.AspNetCore.Mvc;
using q.HandlingNonSuccessStatusCodes1.Models;
namespace q.HandlingNonSuccessStatusCodes1.Controllers
{
    public class ProductsController : Controller
    {
        // Simulate a data source with a static list of products.
        private static List<Product> Products = new List<Product>
        {
            new Product { Id = 1, Name = "Ultra Laptop", Price = 1299.99m },
            new Product { Id = 2, Name = "Smartphone Pro", Price = 899.99m },
            new Product { Id = 3, Name = "Wireless Tablet", Price = 499.99m }
        };

        // GET: /Products/Details/{id}
        public IActionResult Details([FromRoute] int id)
        {
            // Try to fetch the product from the static list
            var product = Products.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                // Set the HTTP status code to 404 (Not Found)
                Response.StatusCode = 404;
                // Render a professionally styled error view for missing products.
                return View("ProductNotFound", id);
            }

            // Render the Details view with the found product.
            return View(product);
        }
    }
}