using Microsoft.AspNetCore.Http;
using Soul.IdentityServer.Models;

namespace Soul.IdentityServer.Validation
{
    public interface IClientCredentialsParser
    {
        Task<ClientCredentials?> ParseAsync(HttpContext context);
    }
}
