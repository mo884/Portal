
using Portal.DAL.DataBase;
using Portal.DAL.Entities;
using Portal.DAL.Repo.Abstraction;
using System.Linq.Expressions;

namespace Portal.DAL.Repo.Impelementation
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly PortalDbContext db;
        public EmployeeRepo()
        {
            db = new PortalDbContext();
        }

        public (bool, string?) Create(Employee employee)
        {
            try
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                if (employee?.Id >0)
                    return (true, null);
                return (false, "Error To Save In Local Db");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public (bool, string?) Edit(Employee emp)
        {
            try
            {
                var employee = db.Employees.Where(a => a.Id == emp.Id).FirstOrDefault();
                if (employee == null)
                    return (false, "Employee Not Found In Local Db");
                var result = employee.Edit("Mohamed Essam", emp.FName, emp.LName, emp.Age, emp.Salary);
                if (result)
                {
                    db.SaveChanges();
                    return (true, null);
                }
                return (false, "Please Enter User Modifier");

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public bool IsDeleted(long id)
        {
            try
            {
                var employee = db.Employees.Where(a => a.Id == id).FirstOrDefault();
                if (employee == null)
                    return (false);
                var result = employee.Deleted("Mohamed Essam");
                if (result)
                {
                    db.SaveChanges();
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public Employee Get(Expression<Func<Employee, bool>>? filter = null)
        {
            if (filter == null)
                return db.Employees.FirstOrDefault();
            var result = db.Employees.Where(filter).FirstOrDefault();
            return result;
        }
        public List<Employee> GetAll(Expression<Func<Employee, bool>>? filter = null)
        {
            if (filter == null)
                return db.Employees.ToList();
            var result = db.Employees.Where(filter).ToList();
            return result;
        }


    }
}
