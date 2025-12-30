using o.FluentApiDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace o.FluentApiDemo.Controllers;

public class HomeController : Controller
{
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegistrationModel model)
    {
        // 1. Default Automatic validation using FluentApi service by the MVC Framework 
        // if (!ModelState.IsValid)
        // {
        //     // Validation failed, return to the form with errors
        //     return View(model);
        // }

        // 2. Manual validation using the validator class
        RegistrationValidator validator = new RegistrationValidator();
        var validationResult = validator.Validate(model);
        if (!validationResult.IsValid)
        {
            return View(model);
        }

        // Handle successful validation logic here
        return RedirectToAction("Success");
    }

    public string Success()
    {
        return "Registration Successful";
    }
}