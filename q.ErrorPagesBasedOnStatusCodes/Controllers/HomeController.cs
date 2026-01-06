using Microsoft.AspNetCore.Mvc;

namespace q.ErrorPagesBasedOnStatusCodes.Controllers;

public class HomeController : Controller
{
    // Default home page action
    public IActionResult Index()
    {
        return View();
    }

    // Simulate a 400 Bad Request error page.
    public IActionResult BadRequestPage()
    {
        // In a real scenario, this might be triggered when the request is malformed.
        bool isBadRequest = true;
        if (isBadRequest)
        {
            // Return HTTP 400 status code to trigger the Bad Request error handling.
            // This will render the Generic error page
            return new StatusCodeResult(400);
        }
        return View();
    }

    // Simulate a 401 Unauthorized error page.
    public IActionResult UnauthorizedPage()
    {
        // Here, we simulate an unauthenticated user scenario.
        bool isAuthenticated = false;
        if (!isAuthenticated)
        {
            // Returns 401 Unauthorized to trigger the custom error view.
            return Unauthorized();
        }
        return View();
    }

    // Simulate a 403 Forbidden error page.
    public IActionResult ForbiddenPage()
    {
        // Simulate a scenario where the user lacks permission.
        bool hasPermission = false;
        if (!hasPermission)
        {
            // Returns HTTP 403 to trigger the Forbidden error view.
            return new StatusCodeResult(403);
        }
        return View();
    }

    // Simulate a 404 Not Found error page.
    public IActionResult NotFoundPage()
    {
        // Simulate a scenario where the requested resource does not exist.
        bool resourceExists = false;
        if (!resourceExists)
        {
            // Returns 404 Not Found to trigger the custom error page.
            return NotFound();
        }
        return View();
    }

    // Simulate a 500 Internal Server Error page.
    public IActionResult InternalServerErrorPage()
    {
        try
        {
            // Simulate code that might throw an exception.
            throw new Exception("Simulated exception for testing 500 error.");
        }
        catch  
        {
            // Log the exception as needed.
            // Returns HTTP 500 to trigger the Internal Server Error view.
            return new StatusCodeResult(500);
        }
    }

    // Simulate a 503 Service Unavailable error page.
    public IActionResult ServiceUnavailablePage()
    {
        // Simulate a scenario where the service is down (maintenance or high load).
        bool serviceDown = true;
        if (serviceDown)
        {
            // Returns 503 Service Unavailable to trigger the custom error view.
            return new StatusCodeResult(503);
        }
        return View();
    }
}