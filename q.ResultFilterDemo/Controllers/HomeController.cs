using q.ResultFilterDemo.Models;
using Microsoft.AspNetCore.Mvc;
namespace q.ResultFilterDemo.Controllers;

public class HomeController : Controller
{

    [CustomResultFilter]
    public IActionResult Index()
    {
        // The view name can be dynamically changed based on the filter
        return View();
    }

    [HttpGet("/async")]
    [TypeFilter(typeof(CustomResultFilterAsync))]
    public IActionResult IndexAsync()
    {
        return View("Index");
    }
}
