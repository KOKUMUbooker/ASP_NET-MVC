using Microsoft.AspNetCore.Mvc;
namespace m.CustomModelBinding.Models;

public class ComplexUser2
{
    [FromHeader(Name = "X-Username")]
    public string? Username { get; set; }

    [FromQuery(Name = "age")]
    public int Age { get; set; }

    [FromRoute(Name = "country")]
    public string? Country { get; set; }

    [FromQuery(Name = "refid")]
    public string? ReferenceId { get; set; }
}