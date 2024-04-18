using Microsoft.AspNetCore.Authorization;

namespace WebApiSchool.Services
{
    public class CustomAuthorizationRequirement : IAuthorizationRequirement
    {
        public string PermissionName { get; }

        public CustomAuthorizationRequirement(string permissionName)
        {
            PermissionName = permissionName;
        }
    }
}
