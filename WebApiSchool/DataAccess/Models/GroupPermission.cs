using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiSchool.DataAccess.Models
{
    public class GroupPermission
    {
        [Key]
        public int Id { get; set; }

        public int PermissionGroupId { get; set; }

        public string PermissionName { get; set; }

        [ForeignKey("PermissionGroupId")]
        public PermissionGroup PermissionGroup { get; set; }
    }
}
