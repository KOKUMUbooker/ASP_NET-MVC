using Microsoft.AspNetCore.Mvc;
namespace k.CustomRouteConstraints.Controllers
{
    public class StudentController : Controller
    {
        public string Index()
        {
            return $"Index() Action Method of StudentController";
        }
        public string Details(string id)
        {
            return $"Details({id}) Action Method of StudentController";
        }
    }
}