using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace m.ModelBindingDemo.Controllers;
public class NoModelBindingController : Controller
{
    public IActionResult Index()
    {
        // Return the default view associated with this action.
        return View();
    }

    // Indicate that this action method handles POST requests.
    [HttpPost]
    // Define the SubmitForm action method, accepting an IFormCollection object as a parameter.
    public IActionResult SubmitForm(IFormCollection form)
    {
        // Use Keys to get the collection of form keys
        var keys = form.Keys; // Retrieve all the keys (form field names) from the form collection and store them in the 'keys' variable.

        // Check if a specific key is present using ContainsKey
        // Check if the form contains the keys "UserName" and "UserEmail".
        if (form.ContainsKey("UserName") && form.ContainsKey("UserEmail"))
        {
            // You Can access the Data using String Indexer
            // var UserName = form["UserName"].ToString();
            // var UserEmail = form["UserEmail"].ToString();

            // Retrieve the value associated with a key using TryGetValue
            if (form.TryGetValue("UserName", out StringValues userName) && form.TryGetValue("UserEmail", out StringValues userEmail))
            // Try to retrieve the value for "UserName" and "UserEmail" from the form.
            // If both keys exist, their values are stored in 'userName' and 'userEmail' respectively.
            {
                // If both values were successfully retrieved, store a success message in ViewBag with the user's name and email.
                ViewBag.Message = $"User Created: UserName: {userName}, UserEmail: {userEmail}";
            }
            else // If either "UserName" or "UserEmail" was not found in the form data,
            {
                // store an error message in ViewBag indicating that the required form data was not found.
                ViewBag.Message = "UserName or UserEmail not found in the form data.";
                
            }
        }
        else // If either the "UserName" or "UserEmail" keys are not present in the form,
        {
            // store a message in ViewBag indicating that the form is missing one or both required keys.
            ViewBag.Message = "Form does not contain UserName or UserEmail.";
        }

        //Return to the Index View
        return View("Index");
    }
}