using TesteTopDownContract.Common;

namespace TesteTopDownApplication.Tokens.Queries.Generate
{
    public record TokenResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType,
    string Token);
}
