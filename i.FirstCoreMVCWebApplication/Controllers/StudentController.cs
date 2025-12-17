using Microsoft.AspNetCore.Mvc;
using i.FirstCoreMVCWebApplication.Models;

namespace i.FirstCoreMVCWebApplication.Controllers;

public class StudentController : Controller
{
    public ViewResult Index()
    {
        return View();
    }

    public ViewResult Test()
    {
        return View("Test");
    }

    public ViewResult TestAbsolute()
    {
        return View("Views/Student/Test.cshtml");
    }
    

    public string GetAllStudents()
    {
        return "Return all students";
    }

    public string GetStudentsByName(string name)
    {
        return $"Return students with Name : {name}";
    }

    public JsonResult GetStudentDetails(int Id)
    {
        StudentRepository repository = new StudentRepository();
        Student studentDetails = repository.GetStudentById(Id);
        return Json(studentDetails);
    }
}