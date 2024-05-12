using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.DataAccess.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.GUID);

            builder.HasOne(u => u.PermissionGroup)
                   .WithMany(pg => pg.Users)
                   .HasForeignKey(u => u.PermissionGroupGUID);

        //    builder.HasData(new List<User>
        //{
        //    new User
        //    {
        //        Id = 1,
        //        Username = "11",
        //        Password = "11",
        //        PermissionGroupId = 1
        //    },
        //    new User
        //    {
        //        Id = 2,
        //        Username = "22",
        //        Password = "22",
        //        PermissionGroupId = 2
        //    },
        //});
        }
    }
}
