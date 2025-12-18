using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using k.AttributeBasedRouting.Models;

namespace k.AttributeBasedRouting.Controllers;

// Without controller decorator
// public class HomeController : Controller
// {
//     [Route("")]
//     [Route("Home")]
//     [Route("Home/Index")]
//     public IActionResult Index() // Sets multiple path definitions
//     {
//         return View();
//     }

//     [Route("MyHome")]
//     [Route("MyHome/Index")]
//     public string StartPage() // Ignores controller name
//     {
//         return "StartPage() Action Method of HomeController";
//     }

//     public IActionResult Privacy() // Still uses convention based routing 
//     {
//         return View();
//     }

//     [Route("Home/Details/{id=10}")]
//     public string Details(int id)
//     {
//         return "Details() Action Method of HomeController, ID Value = " + id;
//     }

//     [HttpGet("~/About")] // Makes route not prepend the controller name - Achieved by either "/About" or "~/About"
//     public string About(int id) // Resolves for the path http://localhost:5276/About
//     {
//         return "About() Action Method of HomeController";
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }

// With controller decorator
[Route("Home")]
public class HomeController : Controller
{
    [Route("")]
    [Route("/")]
    [Route("Index")]
    public IActionResult Index() // Sets multiple path definitions
    {
        return View();
    }

    [Route("MyHome")]
    [Route("MyHome/Index")]
    public string StartPage() // Ignores controller name
    {
        return "StartPage() Action Method of HomeController";
    }

    [Route("Privacy")]
    public IActionResult Privacy()  
    {
        return View();
    }

    [Route("Details/{id=10}")]
    public string Details(int id)
    {
        return "Details() Action Method of HomeController, ID Value = " + id;
    }

    [HttpGet("~/About")] // Makes route not prepend the controller name - Achieved by either "/About" or "~/About"
    public string About() // Resolves for the path http://localhost:5276/About
    {
        return "About() Action Method of HomeController";
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
