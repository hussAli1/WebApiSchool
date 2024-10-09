using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApiSchool.DataAccess.Models
{
    public class User
    {
        [Key]
        public Guid GUID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Guid PermissionGroupGUID { get; set; }

        [ForeignKey("PermissionGroupGUID")]
        public PermissionGroup PermissionGroup { get; set; }
    }
}
