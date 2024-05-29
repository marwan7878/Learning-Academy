using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Models;
using MVCDemo.Repositories;

namespace MVCDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

			builder.Services.AddScoped<DBEntity>();
			builder.Services.AddScoped<IDepartmentRepository, DepartmentMemoryRepository>();

            var app = builder.Build();

            //app.Use(async(HttpContext, next) =>
            //{
            //    await HttpContext.Response.WriteAsync("middleware1\n");
            //    await next();
            //    await HttpContext.Response.WriteAsync("middleware111\n");
            //});
            //app.Use(async(HttpContext, next) =>
            //{
            //    await HttpContext.Response.WriteAsync("middleware2\n");
            //    await next();
            //    await HttpContext.Response.WriteAsync("middleware222\n");
            //});
            //app.Run(async (HttpContext) =>
            //{
            //    await HttpContext.Response.WriteAsync("middleware3\n");
            //});

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();       //go to wwwroot

            app.UseRouting();

            app.UseSession();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
