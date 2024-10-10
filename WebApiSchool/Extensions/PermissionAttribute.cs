using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

public class PermissionAttribute : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    private readonly string[] _roles;     // Array to store roles
    private readonly string _permission;  // Store permission

    // Constructor that accepts roles (comma-separated) and permission
    public PermissionAttribute(string roles, string permission)
    {
        _roles = roles.Split(',').Select(r => r.Trim()).ToArray();  // Split and clean roles
        _permission = permission;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;

        if (!user.Identity.IsAuthenticated)
        {
            context.HttpContext.Response.StatusCode = 401;
            return;
        }

        var hasRequiredRole = _roles.Any(role => user.IsInRole(role));
        if (!hasRequiredRole)
        {
            context.Result = new ForbidResult();
            return;
        }

        var permissions = user.Claims
            .Where(c => c.Type == "Permissions")
            .Select(c => c.Value)
            .ToList();

        if (!permissions.Contains(_permission))
        {
            context.Result = new ForbidResult();
            return;
        }

        await Task.CompletedTask;
    }
}
