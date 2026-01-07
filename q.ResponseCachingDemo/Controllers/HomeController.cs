using Microsoft.AspNetCore.Mvc;
namespace q.ResponseCachingDemo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [ResponseCache(Duration = 300, NoStore = false)]
        public string Index()
        {
            return $"Response Generated at: {DateTime.Now}";
        }
    }
}