using n.DisplayNDisplayFormatAttributes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization; 
using Microsoft.AspNetCore.Mvc.Rendering; 
using System.Globalization; 

namespace n.DisplayNDisplayFormatAttributes.Controllers;

public class EmployeeController : Controller 
{
    public IActionResult Details() 
    {
        // Hardcoded employee details for demonstration purposes.
        var employee = new Employee
        {
            Id = 1, 
            FullName = "Booker Ochieng", 
            Gender = "Male", 
            Age = 25, 
            DateOfJoining = new DateTime(2020, 1, 2), 
            DateOfBirth = new DateTime(2005, 2, 2), 
            EmailAddress = "booker@example.com",
            Salary = 55000m, // m for decimal type
            PersonalWebsite = "https://booker-portfolio.netlify.app", 
            PerformanceRating = 4.5567, 
            JobDescription = string.Empty,
            LastDateOfWorking = null
        };

        // Creating a model for the culture selection dropdown.
        var cultureModel = new CultureViewModel
        {
            // The currently selected culture (from the request's culture).
            SelectedCulture = CultureInfo.CurrentCulture.Name, 

            // List of available cultures for the dropdown.
            Cultures = new List<SelectListItem>
            {
                new SelectListItem { Value = "en-US", Text = "United States" }, // US English culture.
                new SelectListItem { Value = "en-GB", Text = "United Kingdom" }, // UK English culture.
                new SelectListItem { Value = "en-KE", Text = "Kenya" }, // Kenya English culture.
            }
        };

        // Passing the culture selection model to the view using ViewBag.
        ViewBag.CultureModel = cultureModel;

        // Returning the Employee model to the view to render the employee details.
        return View(employee);
    }

    // Action method for setting the selected culture.
    [HttpPost]
    public IActionResult SetCulture(string culture, string returnUrl) 
    {
        // Validate the culture string.
        // CultureInfo.GetCultureInfo ensures the culture string is a valid culture name (e.g., "en-US").
        culture = CultureInfo.GetCultureInfo(culture).Name;

        // Set the culture in a cookie.
        // Append a cookie that stores the selected culture information.
        // The cookie is named based on the default culture name.
        // MakeCookieValue sets the RequestCulture (the culture for both culture and UI culture).
        Response.Cookies.Append(

            // The name of the cookie that stores culture information.
            CookieRequestCultureProvider.DefaultCookieName,

            // The culture to store in the cookie.
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)), 

            //Set the cookie's expiration date to 1 year from now.
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) } 
        );

        // Redirect the user back to the original URL after setting the culture.
        // LocalRedirect ensures that the redirection stays within the application for security purposes.
        return LocalRedirect(returnUrl);
    }
}