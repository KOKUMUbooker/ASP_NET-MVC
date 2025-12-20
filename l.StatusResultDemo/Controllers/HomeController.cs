using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using l.StatusResultDemo.Models;

namespace l.StatusResultDemo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult StatusCode404()
    {
        // Return a 404 Not Found response
        return new StatusCodeResult(404);
    }
    public IActionResult CustomStatusCodeExample()
    {
        // Return a custom status code
        return new StatusCodeResult(403); 
    }

    public IActionResult UnauthorizedExample()
    {
        // Return a 401 Unauthorized response
        // return new UnauthorizedResult();
        return Unauthorized();
    }

    public IActionResult UnauthorizedExample2()
    {
        // Return a 401 Unauthorized response
        return Unauthorized(new { Message = "You Have Not Access to This Page" });
    }

    public ActionResult NotFoundExample()
    {
        // Return a 404 Not Found response
        //return new NotFoundResult("Resource Not Found"); 
        // Or use the shorthand:
        return NotFound("Resource Not Found");
    }

    public IActionResult OkExample()
    {
        // Return a 200 OK response along with Custom Message
        var data = new { Message = "Success" };
        // Returns a JSON object with a 200 OK response
        // return new OkResult                                  (data); 
        return Ok(data); 
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
