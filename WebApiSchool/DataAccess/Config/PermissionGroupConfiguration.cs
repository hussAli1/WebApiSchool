using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.DataAccess.Config
{
    public class PermissionGroupConfiguration : IEntityTypeConfiguration<PermissionGroup>
    {
        public void Configure(EntityTypeBuilder<PermissionGroup> builder)
        {

            builder.HasData(new List<PermissionGroup>
            {
                new PermissionGroup
                {
                    Id = 1,
                    Name = "Admin"
                },
                new PermissionGroup
                {
                    Id = 2,
                    Name = "User"
                },
            });
        }
    }
}
