using Microsoft.EntityFrameworkCore;
using WebApiSchool.DataAccess.Config;
using WebApiSchool.DataAccess.Entities;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PermissionGroup> PermissionGroups { get; set; }
        //public DbSet<GroupPermission> GroupPermissions { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Participant> Particpants { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CourseConfiguration).Assembly);
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<DateOnly>()
                .HaveConversion<DateOnlyConverter>()
                .HaveColumnType("date");
        }
    }
}
