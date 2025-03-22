
using Portal.DAL.DataBase;
using Portal.DAL.Entities;
using Portal.DAL.Repo.Abstraction;

namespace Portal.DAL.Repo.Impelementation
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly PortalDbContext portalDbContext;
        public DepartmentRepo(PortalDbContext portalDbContext)
        {
           this. portalDbContext=portalDbContext;
        }



        public List<Department> GetAll()
        {
            return portalDbContext.Department.ToList();
        }
    }
}
