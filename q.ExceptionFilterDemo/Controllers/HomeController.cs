using q.ExceptionFilterDemo.Models;
using Microsoft.AspNetCore.Mvc;
namespace q.ExceptionFilterDemo.Controllers
{
    public class HomeController : Controller
    {
        [CustomAttributeExceptionFilter]
        public ActionResult Index()
        {
            int x = 10;
            int y = 0;
            int z = x / y;

            return View();
        }

        [ServiceFilter<CustomInterfaceExceptionFilter>]
        public ActionResult IExp()
        {
            int x = 10;
            int y = 0;
            int z = x / y;

            return View("Index");
        }

        [RedirectToErrorViewFilter]
        public ActionResult ThrowErr()
        {
            // Simulate an authorization exception
            throw new UnauthorizedAccessException("Access Denied.");
        }
    }
}