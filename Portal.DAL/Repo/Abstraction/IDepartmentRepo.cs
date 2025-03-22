using Portal.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portal.DAL.Repo.Abstraction
{
    public interface IDepartmentRepo
    {
        List<Department> GetAll();
    }
}
