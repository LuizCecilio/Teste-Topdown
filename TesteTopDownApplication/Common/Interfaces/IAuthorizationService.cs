using ErrorOr;
using TesteTopDownApplication.Common.Security.Request;

namespace TesteTopDownApplication.Common.Interfaces
{
    public interface IAuthorizationService
    {
        ErrorOr<Success> AuthorizeCurrentUser<T>(
            IAuthorizeableRequest<T> request,
            List<string> requiredRoles,
            List<string> requiredPermissions,
            List<string> requiredPolicies);
    }
}
