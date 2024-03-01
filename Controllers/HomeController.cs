using StudentInfo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using StudentInfo.Models.Interface;
using StudentInfo.models;

namespace StudentInfo.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
      
        private readonly IStudentBusiness _studentBusiness;
        private readonly IDepartmentBusiness _departmentBusiness;
        public HomeController(IStudentBusiness studentBusiness, IDepartmentBusiness departmentBusiness)
        {
            //_logger = logger;
            _studentBusiness = studentBusiness;
            _departmentBusiness = departmentBusiness;
        }

        public IActionResult Index()
        {
            return View();
        } public IActionResult Student()
        {
            return View();
        } public IActionResult Department()
        {
            return View();
        }
        public IActionResult StudentsList()
        {
          var list =  _studentBusiness.GetStudent();
            return Json(list);
        } public IActionResult DepartmentList()
        {
          var list = _departmentBusiness.GetDepartment();
            return Json(list);
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
