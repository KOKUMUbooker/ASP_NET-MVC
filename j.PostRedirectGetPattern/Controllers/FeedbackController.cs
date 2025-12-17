using Microsoft.AspNetCore.Mvc;
using j.PostRedirectGetPattern.Models;

namespace j.PostRedirectGetPattern.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Display the form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Process the form
        [HttpPost]
        public IActionResult CreatePOST(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                // Assume the feedback is saved to a database
                TempData["SuccessMessage"] = "Thank you for your feedback!";
                return RedirectToAction("Confirmation");
            }

            // If model state is not valid, show the form again with validation summaries
            return View(feedback);
        }

        // GET: Confirmation page
        [HttpGet]
        public IActionResult Confirmation()
        {
            return View();
        }
    }
}