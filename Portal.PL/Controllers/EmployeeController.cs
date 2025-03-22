using Portal.BL.ModelVM.Employees;
using Portal.DAL.Entities;

namespace Portal.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmeployeeServices emeployeeServices;
        private readonly IDepartmentService departmentService;

        public EmployeeController(IEmeployeeServices emeployeeServices,IDepartmentService departmentService)
        {
            this.emeployeeServices =  emeployeeServices;
            this.departmentService=departmentService;
        }
        public IActionResult Index()
        {
             var result= emeployeeServices.GetAllEmployee();
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()  //strongType
        {
            ViewBag.Departments = departmentService.GetAll();
            return View();
        }



        [HttpPost]
        public IActionResult Create(CreateEmployeeVM emp)
        {

            if(ModelState.IsValid)
            {
                var result = emeployeeServices.Create(emp);
                if (result.Item1 == false)
                {
                    ViewBag.Departments = departmentService.GetAll();
                    ViewBag.Message = result.Item2;
                    return View(emp);

                }
                return RedirectToAction("Index", "Employee");

            }
            ViewBag.Departments = departmentService.GetAll();
            return View(emp);

        }


        //[HttpPost]
        //public IActionResult Create(string fname , string lname , int age , double salary)
        //{
        //    var result = emeployeeServices.Create(fname , lname , age , salary);
        //    if (result.Item1 == false)
        //    {
        //        Employee emp = new Employee(fname , lname , age , salary);
        //        ViewBag.Message = result.Item2;
        //        return View(emp);

        //    }
        //    return RedirectToAction("Index", "Employee");
        //}


        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var employee = emeployeeServices.GetEmployeeById(Id);
            if(employee.Item2 == false)
            {
                ViewBag.Message = employee.Item3;
            }
            return View(employee.Item1);
        }


        [HttpPost]
        public IActionResult Edit(int Id, string fname, string lname, int age, double salary)
        {
            var result = emeployeeServices.Edit(Id,fname, lname, age, salary);
            if (result.Item1 == false)
            {
                Employee emp = new Employee(Id,fname, lname, age, salary);
                ViewBag.Message = result.Item2;
                return View(emp);

            }
            return RedirectToAction("Index", "Employee");

        }
    }
}
