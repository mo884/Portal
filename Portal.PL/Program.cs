using Microsoft.EntityFrameworkCore;
using Portal.BL.Mapper;
using Portal.DAL.DataBase;
using Portal.DAL.Repo.Abstraction;
using Portal.DAL.Repo.Impelementation;

namespace Portal.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //Connection string
            var connectionString = builder.Configuration.GetConnectionString("Essam");

            builder.Services.AddDbContext<PortalDbContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            //builder.Services.AddScoped<IEmeployeeServices, Portal.BL.Services.Impelementation.test>();

            builder.Services.AddScoped<IEmeployeeServices, EmployeeServices>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();


            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

            builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
