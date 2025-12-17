using Microsoft.AspNetCore.Mvc;
using j.DataPassingViewModels.Models;
using j.DataPassingViewModels.ViewModels;

namespace j.DataPassingViewModels.Controllers;

public class HomeController : Controller
    {
        public ViewResult Index()
        {
            Student student = new Student()
            {
                StudentId = 101,
                Name = "James",
                Branch = "CSE",
                Section = "A",
                Gender = "Male"
            };

            //Student Address
            Address address = new Address()
            {
                StudentId = 101,
                City = "Mumbai",
                State = "Maharashtra",
                Country = "India",
                Pin = "400097"
            };

            //Creating the View model
            StudentDetailsViewModel studentDetailsViewModel = new StudentDetailsViewModel()
            {
                Student = student,
                Address = address,
                Title = "Student Details Page",
                Header = "Student Details",
            };


            return View(studentDetailsViewModel);
        }
}
