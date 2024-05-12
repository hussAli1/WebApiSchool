using System.ComponentModel.DataAnnotations;

namespace WebApiSchool.DataAccess.Models
{
    public class PermissionGroup
    {
        [Key]
        public Guid GUID { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }  

        public ICollection<GroupPermission> GroupPermissions { get; set; }
    }
}
