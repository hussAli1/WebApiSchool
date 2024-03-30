using Microsoft.EntityFrameworkCore;
using WebApiSchool.DataAccess.Config;
using WebApiSchool.Models;

namespace WebApiSchool.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
        }
    }
}
