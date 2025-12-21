using Microsoft.AspNetCore.Mvc;
using ModelBindingDemo.Models;

namespace ModelBindingDemo.Controllers;

public class UsersController : Controller
{
private List<User> _users;
public UsersController()
{
    _users = new List<User>()
    {
        new User(){Id =1, Name ="Pranaya", Age = 35},
        new User(){Id =2, Name ="Priyanka", Age = 30},
        new User(){Id =3, Name ="Anurag", Age = 35},
        new User(){Id =4, Name ="Prateek", Age=30},
        new User(){Id =5, Name ="Hina", Age=35}
    };
}

[HttpGet]
[Route("users/{Id}/getdetails")]
public IActionResult GetUserById([FromRoute] int Id)
{
    // Here, you can use the 'id' to fetch user details from a database or other data sources.

    var user = _users.FirstOrDefault(x => x.Id == Id);  
    if (user == null)
    {
        return NotFound();
    }

    return Ok(user);
}

    [HttpGet]
    [Route("users/{Id}/details")]
    public IActionResult GetUserById2([FromRoute(Name ="Id")] int UserId)
    {
        // Here, you can use the 'id' to fetch user details from a database or other data sources.
        var user = _users.FirstOrDefault(x => x.Id == UserId);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}