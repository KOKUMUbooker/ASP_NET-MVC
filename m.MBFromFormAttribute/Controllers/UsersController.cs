using Microsoft.AspNetCore.Mvc;
using m.MBFromFormAttribute.Models;

namespace m.MBFromFormAttribute.Controllers;
public class UsersController : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        // Initialize the User model and pass it to the view
        var model = new User();
        ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
        ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
        return View(model);
    }

    [HttpPost]
    public IActionResult Create([FromForm] User user)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Countries = new List<string> { "United States", "Canada", "United Kingdom", "Australia", "India" };
            ViewBag.Hobbies = new List<string> { "Reading", "Traveling", "Gaming", "Cooking" };
            return View(user);
        }

        // Process the Model, i.e., Save user to database
        // Redirect to another action after successful operation
        return RedirectToAction("Success", user);
    }

    [HttpGet]
    public IActionResult Success(User user)
    {
        return View(user);
    }
}