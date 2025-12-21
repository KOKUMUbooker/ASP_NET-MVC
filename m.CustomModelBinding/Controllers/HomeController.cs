using Microsoft.AspNetCore.Mvc;
using m.CustomModelBinding.Models;

namespace m.CustomModelBinding.Controllers;

public class HomeControlerController : Controller
{
    //[HttpGet("home/getdetails")]
    //public IActionResult GetDetails([ModelBinder] List<int> Ids)
    //{
    //    // Your logic here...
    //    return Ok(Ids);
    //}

    [HttpGet("home/getdetails")]
    public IActionResult GetDetails([ModelBinder(typeof(CommaSeparatedModelBinder))] List<int> Ids)
    {
        // Your logic...
        return Ok(Ids);
    }

    [HttpGet("home/getdata")]
    public IActionResult GetData([ModelBinder(typeof(DateRangeModelBinder))] DateRange range)
    {
        // Do something with range.StartDate and range.EndDate
        return Ok($"From {range.StartDate} to {range.EndDate}");
    }

    [HttpGet("data/{user}")]
    public IActionResult GetComplexUserData([ModelBinder(typeof(ComplexUserModelBinder))] ComplexUser user)
    {
        // Your logic...
        return Ok(user);
    }

    [HttpGet("data2/{user}")]
    public IActionResult GetComplexUserData2(ComplexUser2 user)
    {
        // Your logic...
        return Ok(user);
    }
}