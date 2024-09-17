using TesteTopDownDomain.Users;

namespace TesteTopDownApplication.Tokens.Queries.Generate
{
    public record GenerateTokenResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    SubscriptionType SubscriptionType,
    string Token);
}
