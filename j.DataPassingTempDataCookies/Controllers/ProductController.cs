using Microsoft.AspNetCore.Mvc;
using j.DataPassingTempDataCookies.Models;

namespace TempDataDemo.Controllers
{
    public class ProductController : Controller
    {
        // GET: /Product
        public IActionResult Index()
        {
            // Retrieve all products
            var products = ProductRepository.GetAll();

            // Pass TempData message to ViewBag to display if exists
            ViewBag.SuccessMessage = TempData["SuccessMessage"];

            return View(products);
        }

        // GET: /Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                // Add product to repository
                ProductRepository.Add(product);

                // Set success message in TempData
                TempData["SuccessMessage"] = $"Product '{product.Name}' created successfully!";

                // Redirect to Index (GET)
                return RedirectToAction(nameof(Index));
            }

            // If validation fails, show form again with errors
            return View(product);
        }
    }
}