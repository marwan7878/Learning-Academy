using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Filters;
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
            builder.Services.AddControllersWithViews(
                options=>options.Filters.Add(new HandleErrorAttribute())
                );
            
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            builder.Services.AddDbContext<DBEntity>(options=>
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"))
                );

            //AddSingletone >> create object per project 
            //AddScoped >> create object per request 
            //AddTransient >> create object per injection (view , method and constructor) 
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

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
