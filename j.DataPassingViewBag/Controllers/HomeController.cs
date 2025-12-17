using Microsoft.AspNetCore.Mvc;
using j.DataPassingViewBag.Models;

namespace j.DataPassingViewBag.Controllers;

public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //String string Data
            ViewBag.Title = "Student Details Page";
            ViewBag.Header = "Student Details";

            Student student = new Student()
            {
                StudentId = 101,
                Name = "James",
                Branch = "CSE",
                Section = "A",
                Gender = "Male"
            };

            //storing Student Data
            ViewBag.Student = student;

            return View();
        }
}
