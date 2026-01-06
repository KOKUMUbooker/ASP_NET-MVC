using Microsoft.AspNetCore.Mvc;

namespace q.UseStatusCodePagesWithRedirectsDemo.Controllers
{
    public class ErrorController : Controller
    {
        // This route catches any error code passed in the URL, e.g., /Error/404
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler([FromRoute] int statusCode)
        {
            // Set a proper error message based on the status code
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found.";
                    break;
                default:
                    ViewBag.ErrorMessage = "An unexpected error occurred. Please try again later.";
                    break;
            }
            // Render NotFound view
            return View("NotFound");
        }
    }
}