using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TesteTopDownDomain.Users;

namespace TesteTopDownApplication.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(
            Guid id,
            string firstName,
            string lastName,
            string email,
            SubscriptionType subscriptionType,
            List<string> permissions,
            List<string> roles);
    }
}
