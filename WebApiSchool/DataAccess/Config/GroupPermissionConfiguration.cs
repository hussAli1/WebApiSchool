using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.DataAccess.Config
{

    public class GroupPermissionConfiguration : IEntityTypeConfiguration<GroupPermission>
    {
        public void Configure(EntityTypeBuilder<GroupPermission> builder)
        {
            builder.HasKey(gp => new { gp.PermissionGroupGUID, gp.PermissionName });

            builder.HasOne(gp => gp.PermissionGroup)
                   .WithMany(pg => pg.GroupPermissions)
                   .HasForeignKey(gp => gp.PermissionGroupGUID);

        //    builder.HasData(new List<GroupPermission>
        //{
        //    new GroupPermission
        //    {
        //        GUID=1,
        //        PermissionGroupGUID = 1,
        //        PermissionName = "GetCourse"
        //    },
        //    new GroupPermission
        //    {
        //        Id = 2,
        //        PermissionGroupId = 2,
        //        PermissionName = "GetCourseById"
        //    },
        //});
        }
    }
}
