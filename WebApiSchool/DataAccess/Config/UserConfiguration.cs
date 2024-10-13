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
        //        GUID = Guid.Parse("02F588E5-942D-4DBE-A6AE-046A7F60E9E4"),
        //        Username = "11",
        //        Password = "11",
        //        PermissionGroupGUID = Guid.Parse("0E9F9C94-1437-4FF9-8D12-0000FE93FD71"),
        //    },
        //    new User
        //    {
        //        GUID = Guid.Parse("B1B62BB0-17B6-4401-A0C7-54C8279B8D0D"),
        //        Username = "22",
        //        Password = "22",
        //        PermissionGroupGUID = Guid.Parse("F9F68922-9C6D-4142-BC8C-000AB06B5AB3"),

        //    },
        //});
        }
    }
}
