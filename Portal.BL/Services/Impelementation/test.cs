using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.BL.Services.Impelementation
{
    public class test 
    {
        public (bool, string) Create(string fname, string lname, int age, double salary)
        {
            throw new NotImplementedException();
        }

        public (bool, string) Edit(int Id, string fname, string lname, int age, double salary)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployee()
        {
            throw new NotImplementedException();
        }

        public (Employee?, bool, string?) GetEmployeeById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
