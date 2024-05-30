
using Microsoft.EntityFrameworkCore;
using MVCDemo.ViewModels;

namespace MVCDemo.Models
{
    public class DBEntity : DbContext
    {
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Trainee> Trainee { get; set; }
        public DbSet<CourseResult> CourseResult { get; set; }
        public DbSet<Instructor> Instructor { get; set; }

        public DBEntity():base()
        {

        }
        public DBEntity(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=MAROOO;Initial Catalog=MVCDemo;Integrated Security=True;Encrypt=False");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<MVCDemo.ViewModels.CourseResultViewModel> CourseResultViewModel { get; set; } = default!;

    }
}
