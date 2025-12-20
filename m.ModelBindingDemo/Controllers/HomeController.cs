using Microsoft.AspNetCore.Mvc;
using m.ModelBindingDemo.Models;

namespace m.ModelBindingDemo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitForm(User user)
    {
        if (user != null)
        {
            if (ModelState.IsValid)
            {
                // Store success message in ViewBag
                ViewBag.Message = $"User Created: UserName: {user.UserName}, UserEmail: {user.UserEmail}";

                // Optionally, you could clear the model to reset the form if needed
                ModelState.Clear();

                return View("Index");
            }
        }
        return View("Index", user); // Return the Index view with the user model
    }
}
