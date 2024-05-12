using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.DataAccess.Config
{
    public class SectionConfiguration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x=>x.GUID);
            builder.Property(x => x.GUID).ValueGeneratedNever();


            builder.Property(x => x.SectionName)
                .HasColumnType("Varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(x => x.Course)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.CourseGUID)
                .IsRequired();

            builder.OwnsOne(x => x.TimeSlot, ts =>
            {
                ts.Property(p => p.StartTime).HasColumnType("time(0)").HasColumnName("StartTime").IsRequired();
                ts.Property(p => p.EndTime).HasColumnType("time(0)").HasColumnName("EndTime").IsRequired();
            });

            builder.OwnsOne(x => x.DateRange, ts =>
            {
                ts.Property(p => p.StartDate).HasColumnType("date").HasColumnName("StartDate").IsRequired();
                ts.Property(p => p.EndDate).HasColumnType("date").HasColumnName("EndDate").IsRequired();
            });

            builder.HasOne(x => x.Schedule)
                .WithMany(x => x.Sections)
                .HasForeignKey(x=>x.ScheduleGUID)
                .IsRequired();

            builder.HasOne(x => x.Instructor)
                .WithMany(x => x.Sections)
                .HasForeignKey(x => x.InstructorGUID)
                .IsRequired(false);

            builder.HasMany(x => x.Participants)
                .WithMany(x => x.Sections).
                UsingEntity<Enrollment>();

            builder.ToTable("Sections");
        }
    }
}
