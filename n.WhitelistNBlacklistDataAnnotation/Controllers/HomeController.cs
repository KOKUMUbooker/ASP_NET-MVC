using Microsoft.AspNetCore.Mvc;
using n.WhitelistNBlacklistDataAnnotation.Models;

namespace n.WhitelistNBlacklistDataAnnotation.Controllers;

public class HomeController : Controller
{
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Create(UserInput model)
    {
        //Check if the Model State is Valid
        if (ModelState.IsValid)
        {
            //Save the Data into the Database
            //Redirect to a Different View
            return RedirectToAction("Successful");
        }

        //Return to the same View and Display Model Validation error
        return View(model);
    }

    public string Successful()
    {
        return "Role Added Successfully";
    }
}