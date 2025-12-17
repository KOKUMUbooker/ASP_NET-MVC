using Microsoft.AspNetCore.Mvc;

namespace i.FirstCoreMVCWebApplication.Controllers;

public class ProductController : Controller
{
    public string Index()
    {
        return "This is the product controller";
    }

    public string Hello()
    {
        return "Konnichiwa";
    }
}