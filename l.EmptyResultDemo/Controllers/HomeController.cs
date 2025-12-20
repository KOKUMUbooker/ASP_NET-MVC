using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using l.EmptyResultDemo.Models;

namespace l.EmptyResultDemo.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult ProcessRequest()
    {
        // Perform some processing

        // Return an empty HTTP response
        return new EmptyResult();
    }

    public IActionResult DeleteResource()
    {
        // Delete the resource
        // Return a 204 No Content response with an EmptyResult
        return NoContent();
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
