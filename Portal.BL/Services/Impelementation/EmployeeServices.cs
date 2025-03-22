using AutoMapper;
using Portal.BL.Helper;
using Portal.BL.ModelVM.Employees;

namespace Portal.BL.Services.Impelementation
{
    public class EmployeeServices : IEmeployeeServices
    {
        private readonly IEmployeeRepo employeeRepo;
        private readonly IMapper mapper;

        public EmployeeServices(IEmployeeRepo employeeRepo,IMapper mapper)
        {
            this.employeeRepo = employeeRepo;
            this.mapper=mapper;
        }

        public (bool, string) Create(CreateEmployeeVM empvm)
        {
            try
            {
                string Path = null;
                if(empvm.Image is not null)
                {
                    Path = UploadFiles.UploadFile("Profiles",empvm.Image);
                }
                var employee = new Employee(empvm.FName, empvm.LName, empvm.Age, empvm.Salary, empvm.DeptId, Path);
                var result = employeeRepo.Create(employee);
                return result;
            }
            catch (Exception ex)
            {
                return (false,ex.Message);
            }
        }

        public (bool, string) Edit(int Id, string fname, string lname, int age, double salary)
        {
            try
            {
                //Check if Employee Is Found In Db
                var employee = employeeRepo.Get(a => a.Id == Id);
                if (employee == null)
                    return (false, "Employee not found in local db!");

                //make update
                var result = employeeRepo.Edit(new (fname, lname,age,salary,0) , Id);
               
                return result;
            }
            catch (Exception ex)
            {

                return ( false, ex.Message);
            }

        }

        public List<GetAllEmployeeVM> GetAllEmployee()
        {
            var employees = employeeRepo.GetAll();
            var result = mapper.Map<List<GetAllEmployeeVM>>(employees);
         
            return result;
        }

        public (Employee?,bool,string?) GetEmployeeById(int id)
        {
            try
            {
                var result = employeeRepo.Get(a=>a.Id ==id);
                if (result == null)
                    return (null, false, "Employee not found in local db!");
                return (result, true, null);

            }
            catch (Exception ex)
            {
                return (null, false, ex.Message);

            }
        }
    }
}
