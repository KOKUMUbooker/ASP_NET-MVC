using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using l.ContentResultDemo.Models;
using Newtonsoft.Json;

namespace l.ContentResultDemo.Controllers;

[Route("/[action]")]
public class HomeController : Controller
{
    [Route("")]
    [Route("/")]
    public ContentResult Index()
    {
        // Declare a string variable to hold the plain text content
        string plainText = "This is plain text content.";
        // Create and return a new ContentResult object
        return new ContentResult
        {
            // Set the ContentType property to "text/plain" to indicate the MIME type of the content
            ContentType = "text/plain",
            // Set the Content property to the plainText string, which contains the content to be returned
            Content = plainText,
            StatusCode = 200, // OK status code
        };

        // // Using the Content helper method from the controller class
        // return Content(plainText,"text/plain");
    }

    public ContentResult Html()
    {
        string htmlContent = "<html><body><h1>Hello, Welcome to Dot Net Tutorials</h1></body></html>";
        
        return Content(htmlContent, "text/html");
    }

    public ContentResult Xml()
    {
        string xmlContent = "<?xml version=\"1.0\" encoding=\"UTF-8\"?><data><item>Hello Dot Net Tutorials</item></data>";        
        
        return Content(xmlContent, "application/xml");
    }

    public ContentResult Str()
    {
        string content = "This is a simple string.";
        
        return Content(content); // If mime type not set, defaults to "text/plain"
    }


    public ContentResult JSON()
    {
            // Create an anonymous object containing data to be serialized into JSON
            var jsonData = new { Name = "Pranaya", Age = 35, Occupation = "Manager" };
            // Serialize the jsonData object to a JSON string using JsonConvert.SerializeObject
            var jsonSerializedString = JsonConvert.SerializeObject(jsonData);

        return Content(jsonSerializedString, "application/json");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
