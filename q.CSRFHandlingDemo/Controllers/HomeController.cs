using Microsoft.AspNetCore.Mvc;
namespace q.CSRFHandlingDemo.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult ChangePin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePin(string AccountNumber, string Pin, string __RequestVerificationToken)
        {
            Console.WriteLine($"AntiForgeryToken from ChangePin POST action : {__RequestVerificationToken}");
            // Process the data
           
            TempData["Message"]= $"AccountNumber: {AccountNumber} Pin Changed to: {Pin}";

            return RedirectToAction("PinChangeSuccess");
        }

        public ActionResult PinChangeSuccess()
        {
            return View();
        }
    }
}