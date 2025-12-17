using Microsoft.AspNetCore.Mvc;
using i.DependencyInjection.Models;

namespace i.DependencyInjection.Controllers;

// =========== Without dependency injection ===========
// public class StudentController : Controller
// {
//         public JsonResult Index()
//         {
//             StudentRepository repository = new StudentRepository();
//             List<Student> allStudentDetails = repository.GetAllStudent();
//             return Json(allStudentDetails);
//         }

//         public JsonResult GetStudentDetails(int Id)
//         {
//             StudentRepository repository = new StudentRepository();
//             Student studentDetails = repository.GetStudentById(Id);
//             return Json(studentDetails);
//         }
// }

// ========= 1. With Dependency Injection(Constructor Method Injection) - Service accessed via constructor
// public class StudentController : Controller
// {
//     private readonly IStudentRepository? _repository;

//     public StudentController(IStudentRepository repository)
//     {
//         _repository = repository;
//     }

//     public JsonResult Index()
//     {
//         List<Student>? allStudentDetails = _repository?.GetAllStudent();
//         return Json(allStudentDetails);
//     }

//     public JsonResult GetStudentDetails(int Id)
//     {
//         Student? studentDetails = _repository?.GetStudentById(Id);
//         return Json(studentDetails);
//     }
// }

// ========= 2. With Dependency Injection(Action Method Injection) - Service accessed via Action method
// public class StudentController : Controller
// {

//     public JsonResult Index([FromServices] IStudentRepository repository)
//     {
//         List<Student> allStudentDetails = repository.GetAllStudent();
//         return Json(allStudentDetails);
//     }

//     public JsonResult GetStudentDetails(int Id,[FromServices] IStudentRepository repository)
//     {
//         Student studentDetails = repository.GetStudentById(Id);
//         return Json(studentDetails);
//     }
// }

// ========= 3. With Dependency Injection - Service accessed manually from HttpContext's property field RequestSerices
public class StudentController : Controller
{

    public JsonResult Index()
    {
        var services = this.HttpContext.RequestServices;
        IStudentRepository? _repository = services.GetService<IStudentRepository>();
   
        List<Student>? allStudentDetails = _repository?.GetAllStudent();
        return Json(allStudentDetails);
    }

    public JsonResult GetStudentDetails(int Id)
    {
        var services = this.HttpContext.RequestServices;
        IStudentRepository? _repository = services.GetService<IStudentRepository>();
   
        Student? studentDetails = _repository?.GetStudentById(Id);
        return Json(studentDetails);
    }
}