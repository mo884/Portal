using Portal.DAL.Entities;
using System;
using System.Linq.Expressions;

namespace Portal.DAL.Repo.Abstraction
{
    public interface IEmployeeRepo
    {
        //Command
        (bool,string?) Create(Employee employee);
        (bool, string?) Edit(Employee emp, int Id);
        bool IsDeleted(long  id);
        //Query
        Employee Get(Expression<Func<Employee, bool>> ? filter = null);
        List<Employee> GetAll(Expression<Func<Employee, bool>>? filter = null);
    }
}
