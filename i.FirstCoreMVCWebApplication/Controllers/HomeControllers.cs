using Microsoft.AspNetCore.Mvc;

namespace i.FirstCoreMVCWebApplication.Controllers;

public class HomeController : Controller
{
    public string Index()
    {
        return "This is Index action from MVC Controller";
    }
}

