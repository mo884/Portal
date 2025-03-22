using Microsoft.EntityFrameworkCore;
using Portal.DAL.Entities;

namespace Portal.DAL.DataBase
{
    public class PortalDbContext : DbContext
    {
        public PortalDbContext(DbContextOptions<PortalDbContext> options):base(options)
        {
            
        }
        //Encapsulated

        public DbSet<Employee>Employees { get; set; }
        public DbSet<Department> Department { get; set; }

    }
}
