using Microsoft.AspNetCore.Mvc;
using n.WhitelistNBlacklistDataAnnotation.Models;

namespace n.WhitelistNBlacklistDataAnnotation.Controllers;

public class BlogCommentController : Controller
{
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(BlogComment blogComment)
    {
        if (ModelState.IsValid)
        {
            //Save the Data into the Database
            //Redirect to a Different View
            return RedirectToAction("Successful");

        }

        // If validation fails, show form again with validation messages
        return View(blogComment);
    }

    public string Successful()
    {
        return "Comment Posted Successfully!";
    }
}