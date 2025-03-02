using ModelRepo;
using ServiceRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeCRUD2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _Iemp;
        public HomeController(IEmployeeService Iemp)
        {
            _Iemp = Iemp;
        }
        public ActionResult Index()
        {
            List<Employee> emp = _Iemp.GetAllEmp();
            return View(emp);
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}