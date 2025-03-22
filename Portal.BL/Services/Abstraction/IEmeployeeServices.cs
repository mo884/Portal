using Portal.BL.ModelVM.Employees;
using Portal.DAL.Entities;

namespace Portal.BL.Services.Abstraction
{
    public interface IEmeployeeServices
    {
        List<GetAllEmployeeVM> GetAllEmployee();
        (bool, string) Create(CreateEmployeeVM empvm);
        (bool, string) Edit(int Id,string fname, string lname, int age, double salary);

        (Employee?, bool, string?) GetEmployeeById(int id);
    }
}
