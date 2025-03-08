using Microsoft.AspNetCore.Mvc;

namespace Portal.PL.Controllers
{
    public class EssamController : Controller
    {
        private readonly IEmeployeeServices emeployeeServices;
        public EssamController()
        {
            emeployeeServices = new EmployeeServices();

        }
        public IActionResult Test1()
        {
            ViewBag.Employees = emeployeeServices.GetAllEmployee();
            return View();
        }

        public IActionResult Test2()
        {

            return View();
        }


        public IActionResult Test3()
        {
            return View();
        }
    }
}
