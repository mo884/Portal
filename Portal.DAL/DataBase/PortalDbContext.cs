using Microsoft.EntityFrameworkCore;
using Portal.DAL.Entities;

namespace Portal.DAL.DataBase
{
    public class PortalDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=PortalMVC;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
        }
        public DbSet<Employee>Employees { get; set; }
    }
}
