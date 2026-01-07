using q.ActionFiltersDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace q.ActionFiltersDemo.Controllers
{
    [TypeFilter(typeof(LoggingFilterAttribute))]
    public class HomeController : Controller
    {
        [TypeFilter(typeof(AsyncCachingFilter))]
        public IActionResult Index()
        {
            // Storing the current time in ViewBag
            ViewBag.CurrentTime = DateTime.Now;

            return View();
        }

        [DataTransformationFilter]
        public IActionResult Details()
        {
            var model = new MyCustomModel
            {
                Name = "Initial Name",
                Address = "Initial Address"
            };
            //return Ok(model);
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [TypeFilter(typeof(CustomValidationFilter))]
        [HttpPost]
        public IActionResult Create(MyCustomModel model)
        {
            if (ModelState.IsValid)
            {
                // Process the valid model here
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [TypeFilter(typeof(ErrorHandlerFilterAttribute))]
        public IActionResult Error()
        {
            throw new Exception("This is a forced error!");
        }
    }
}