namespace Portal.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmeployeeServices emeployeeServices;
        public EmployeeController()
        {
            emeployeeServices = new EmployeeServices();
        }
        public IActionResult Index()
        {
            ViewBag.Employees = emeployeeServices.GetAllEmployee();
            return View();
        }
    }
}
