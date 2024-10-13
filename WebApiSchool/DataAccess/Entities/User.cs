using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApiSchool.DataAccess.Entities;

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

        public ICollection<Post> Posts { get; set; }

        public static implicit operator User(Task<User> v)
        {
            throw new NotImplementedException();
        }
    }
}
