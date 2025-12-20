using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using l.ObjectResultDemo.Models;

namespace l.ObjectResultDemo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetPerson()
    {
        var person = new { FirstName = "Pranaya", LastName = "Rout", Age = 35 };
        // Return an ObjectResult with JSON serialization
        return new ObjectResult(person); 
        // Or use the shorthand:
        // return Ok(person);
    }

    public IActionResult GetPerson2()
    {
        var person = new { FirstName = "John", LastName = "Doe", Age = 35 };
        var result = new ObjectResult(person)
        {
            StatusCode = 200, // HTTP status code
            ContentTypes = new MediaTypeCollection
            {
                "application/json" // Content type(s)
            }
        };
        return result;
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
