using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiSchool.DataAccess.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int PermissionGroupId { get; set; }

        [ForeignKey("PermissionGroupId")]
        public PermissionGroup PermissionGroup { get; set; }
    }
}
