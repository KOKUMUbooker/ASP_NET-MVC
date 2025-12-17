using Microsoft.AspNetCore.Mvc;
using j.DataPassingViewData.Models;

namespace j.DataPassingViewData.Controllers;

public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //String string Data
            ViewData["Title"] = "Student Details Page";
            ViewData["Header"] = "Student Details";

            Student student = new Student()
            {
                StudentId = 101,
                Name = "James",
                Branch = "CSE",
                Section = "A",
                Gender = "Male"
            };

            //storing Student Data
            ViewData["Student"] = student;

            return View();
        }
}
