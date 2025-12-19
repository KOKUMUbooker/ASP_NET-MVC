using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using l.JsonResultDemo.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace l.JsonResultDemo.Controllers;

[Route("/[action]")]
public class HomeController : Controller
{
    [Route("")]
    [Route("/")]
    public IActionResult Index()
    {
        var jsonData = new
        {
            Name = "Pranaya",
            ID = 4,
            DateOfBirth = new DateTime(1988, 02, 29)
        };

        return new JsonResult(jsonData); // Creating a JsonResult instance
        // return Json(jsonData); // Using Json helper func from the Controller class 
    }

    public IActionResult Students()
    {
        var jsonArray = new[]
        {
            new { Name = "Pranaya", Age = 25, Occupation = "Designer" },
            new { Name = "Ramesh", Age = 30, Occupation = "Manager" }
        };
        
        return Json(jsonArray);
    }

     public JsonResult Employees()
        {
            // Create a new instance of JsonSerializerOptions
            var options = new JsonSerializerOptions
            {
                // Property names will remain as defined in the class
                PropertyNamingPolicy = null,
                // JSON will be formatted with indents for readability
                WriteIndented = true,
                // Properties with null values will be ignored
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                // Read-only properties will be ignored during serialization
                IgnoreReadOnlyProperties = true, 
            };
            // Create a list of Employee objects with sample data
            var jsonArray = new List<Employee>()
            {
                new Employee() { Id = 1, FirstName = "Pranaya", Age = 25, Occupation = "Designer", Address = "BBSR" },
                new Employee() { Id = 2, FirstName = "Ramesh", Age = 30, Occupation = "Manager" }
            };
            // Return the list as a JSON result, using the specified JsonSerializerOptions
            return Json(jsonArray, options);
        }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
