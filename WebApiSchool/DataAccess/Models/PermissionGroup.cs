using System.ComponentModel.DataAnnotations;

namespace WebApiSchool.DataAccess.Models
{
    public class PermissionGroup
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<User> Users { get; set; }  

        public ICollection<GroupPermission> GroupPermissions { get; set; }
    }
}
