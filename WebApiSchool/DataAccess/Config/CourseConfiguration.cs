using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiSchool.Models;

namespace WebApiSchool.DataAccess.Config
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.GUID);
            builder.Property(x => x.GUID)
               .ValueGeneratedOnAdd();

            builder.Property(x=>x.CourseName)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(255).IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(18, 2);

            builder.ToTable("Courses");

            builder.HasData(new List<Course>()
            {
                new Course
                {
                    GUID = Guid.NewGuid(),
                    CourseName = "HCi",
                    Price = 100m
                }
            });

        }
    }
}
