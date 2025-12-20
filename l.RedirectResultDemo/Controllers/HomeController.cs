using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using l.RedirectResultDemo.Models;

namespace l.RedirectResultDemo.Controllers;

public class HomeController : Controller
{
    
    public RedirectResult Index()
    {
        var redirectResult = new RedirectResult("https://dotnettutorials.net")
        {
            // Setting the Permanent property to false, meaning the redirection is temporary
            Permanent = false,
            // Setting the PreserveMethod property to true, meaning the HTTP method used (GET, POST, etc.) will be preserved in the redirect
            PreserveMethod = true
        };
        // Returning the RedirectResult object to the client, causing the browser to redirect to the specified URL
        return redirectResult;

        // return Redirect("https://dotnettutorials.net"); // Or use the Redirect helper method from the Controller class
    }

    public RedirectToRouteResult RedirectToRouteRes()
    {
        // return RedirectToRoute("AboutRoute"); // Will look in the routetable for a the entry with name "AboutRoute"
        return RedirectToRoute(new { controller = "Home", action = "About" });
    }

    public RedirectToRouteResult RedirectToRouteRes2()
    {
        // return RedirectToRoute("AboutRoute",new {Id = 3}); // Will look in the routetable for a the entry with name "AboutRoute"
        return RedirectToRoute(new { controller = "Home", action = "About2", Id = 2 });
    }

    // Defining the Index action method which returns a RedirectToRouteResult
    public RedirectToRouteResult RedirectToRouteRes3()
    {
        // Defining route values as an anonymous object with controller, action, id, and name
        var routeValues = new { controller = "Home", action = "About2", id = 123, name = "test" };
        // Creating a new RedirectToRouteResult object with specified route values
        var redirectResult = new RedirectToRouteResult(
            routeName: null,          // No specific route name
            routeValues: routeValues, // Route values defined earlier
            permanent: false,         // Temporary redirection
            fragment: "AboutSection"  // URL fragment identifier
        );
        // Returning the RedirectToRouteResult object to the client, causing a redirect based on route values
        return redirectResult;
    }

    public RedirectToActionResult RedirectToActionResultRes()
    {
        // Perform Some Logic
        // Redirect to the About action with a Route Parameter
        //return RedirectToAction("About3", new { id = 123 });
        // Redirect to the About action with a Route Parameter Id and a Query String Parameter name 
        return RedirectToAction("About3", "Home", new { id = 123, name = "Index" });
    }

    // Define an action method named Index that returns a RedirectToActionResult
    public RedirectToActionResult RedirectToActionResultRes2()
    {
        // Create an anonymous object to hold route values (id and name)
        var routeValues = new { id = 123, name = "Test" };
        // Create a new instance of RedirectToActionResult
        // Specify the action name ("About"), controller name ("Home"), route values, 
        // and additional options (permanent and preserveMethod)
        var redirectResult = new RedirectToActionResult(
            actionName: "About3",          // The action to redirect to
            controllerName: "Home",       // The controller to redirect to
            routeValues: routeValues,     // The route values to pass to the action
            permanent: false,             // Indicates if the redirect is permanent (HTTP 301)
            preserveMethod: true,         // Indicates if the HTTP method should be preserved
            fragment: "AboutSection"       //Indicates the URL Fragment, i.e., append in the URL as #AboutSection
        );
        // Return the RedirectToActionResult to the framework, which will handle the redirection
        return redirectResult;
    }

    public string About()
    {
        return "Hello and Welcome to Dot Net Tutorials";
    }
    public string About2(int id)
    {
        return $"Hello and Welcome to Dot Net Tutorials with id : {id}";
    }

    public string About3(int id, string name)
    {
        // Return a formatted string that includes the id and name parameters
        return $"Hello and Welcome to Dot Net Tutorials, Id{id}, Name:{name} ";
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
