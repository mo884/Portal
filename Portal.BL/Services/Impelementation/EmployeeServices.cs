
using Portal.BL.Services.Abstraction;
using Portal.DAL.Entities;
using Portal.DAL.Repo.Abstraction;
using Portal.DAL.Repo.Impelementation;

namespace Portal.BL.Services.Impelementation
{
    public class EmployeeServices : IEmeployeeServices
    {
        private readonly IEmployeeRepo employeeRepo;
        public EmployeeServices()
        {
            employeeRepo = new EmployeeRepo();
        }
        public List<Employee> GetAllEmployee()
        {
            return employeeRepo.GetAll();
        }
    }
}
