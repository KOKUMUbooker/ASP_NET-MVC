using Microsoft.AspNetCore.Mvc;
namespace q.UseExceptionHandler.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            int x = 10;
            int y = 0;
            int z = x / y;

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}