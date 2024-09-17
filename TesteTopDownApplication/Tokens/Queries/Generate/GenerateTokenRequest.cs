using TesteTopDownContract.Common;

namespace TesteTopDownApplication.Tokens.Queries.Generate
{
    public record GenerateTokenRequest(
    Guid? Id,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType,
    List<string> Permissions,
    List<string> Roles);
}
