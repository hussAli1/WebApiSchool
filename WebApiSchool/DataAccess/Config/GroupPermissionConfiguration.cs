using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.DataAccess.Config
{

    public class GroupPermissionConfiguration : IEntityTypeConfiguration<GroupPermission>
    {
        public void Configure(EntityTypeBuilder<GroupPermission> builder)
        {
            builder.HasKey(gp => new { gp.PermissionGroupId, gp.PermissionName });

            builder.HasOne(gp => gp.PermissionGroup)
                   .WithMany(pg => pg.GroupPermissions)
                   .HasForeignKey(gp => gp.PermissionGroupId);

        //    builder.HasData(new List<GroupPermission>
        //{
        //    new GroupPermission
        //    {
        //        PermissionGroupId = 1,
        //        PermissionName = "GetCourse"
        //    },
        //    new GroupPermission
        //    {
        //        PermissionGroupId = 2,
        //        PermissionName = "GetCourseById"
        //    },
        //});
        }
    }
}
