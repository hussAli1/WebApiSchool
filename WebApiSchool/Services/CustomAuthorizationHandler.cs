using Microsoft.AspNetCore.Authorization;

namespace WebApiSchool.Services
{
    public class CustomAuthorizationHandler : AuthorizationHandler<CustomAuthorizationRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CustomAuthorizationRequirement requirement)
        {
            // Implement your authorization logic here
            if (context.User.HasClaim(c => c.Type == "Permission" && c.Value == requirement.PermissionName))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
