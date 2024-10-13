using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApiSchool.DataAccess.Models;

namespace WebApiSchool.DataAccess.Config
{
    public class PermissionGroupConfiguration : IEntityTypeConfiguration<PermissionGroup>
    {
        public void Configure(EntityTypeBuilder<PermissionGroup> builder)
        {

            //builder.HasData(new List<PermissionGroup>
            //{
            //    new PermissionGroup
            //    {
            //        GUID = Guid.Parse("0E9F9C94-1437-4FF9-8D12-0000FE93FD71"),
            //        Name = "admin"
            //    },
            //    new PermissionGroup
            //    {
            //        GUID = Guid.Parse("F9F68922-9C6D-4142-BC8C-000AB06B5AB3"),
            //        Name = "user"
            //    },
            //});
        }
    }
}
