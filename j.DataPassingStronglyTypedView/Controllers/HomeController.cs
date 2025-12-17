using Microsoft.AspNetCore.Mvc;
using j.DataPassingStronglyTypedView.Models;

namespace j.DataPassingStronglyTypedView.Controllers;

public class HomeController : Controller
    {
        public ViewResult Index()
        {
            // Using ViewBag
            ViewBag.Title = "Student Details Page";
            // Using ViewData
            ViewData["Header"] = "Student Details";

            Student student = new Student()
            {
                StudentId = 101,
                Name = "James",
                Branch = "CSE",
                Section = "A",
                Gender = "Male"
            };

            return View(student);
        }
}
