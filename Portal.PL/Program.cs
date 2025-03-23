using Hangfire;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Portal.BL.Mapper;
using Portal.DAL.DataBase;
using Portal.DAL.Repo.Abstraction;
using Portal.DAL.Repo.Impelementation;
using Portal.PL.Language;
using System.Globalization;

namespace Portal.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization(options =>
                {
	                options.DataAnnotationLocalizerProvider = (type, factory) =>
		                factory.Create(typeof(SharedResource));
                }); 
			//Connection string
			var connectionString = builder.Configuration.GetConnectionString("Essam");

            builder.Services.AddDbContext<PortalDbContext>(options =>
            options.UseLazyLoadingProxies().UseSqlServer(connectionString));
            //HangFire
            builder.Services.AddHangfire(x => x.UseSqlServerStorage(connectionString));
            builder.Services.AddHangfireServer();


            //builder.Services.AddScoped<IEmeployeeServices, Portal.BL.Services.Impelementation.test>();

            builder.Services.AddScoped<IEmeployeeServices, EmployeeServices>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();


            builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();

            builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));
            var app = builder.Build();


			var supportedCultures = new[] {
					  new CultureInfo("ar-EG"),
					  new CultureInfo("en-US"),
                     new CultureInfo(""),
                };


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
			app.UseRequestLocalization(new RequestLocalizationOptions
			{
				DefaultRequestCulture = new RequestCulture("en-US"),
				SupportedCultures = supportedCultures,
				SupportedUICultures = supportedCultures,
				RequestCultureProviders = new List<IRequestCultureProvider>
				{
				new QueryStringRequestCultureProvider(),
				new CookieRequestCultureProvider()
				}
			});
			app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.UseHangfireDashboard("/Hangfire");
            app.Run();
        }
    }
}
