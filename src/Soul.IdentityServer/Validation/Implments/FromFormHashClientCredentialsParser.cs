using Microsoft.AspNetCore.Http;

namespace Soul.IdentityServer.Validation
{
    internal class FromFormHashClientCredentialsParser : IClientCredentialsParser
    {
        public Task<ClientCredentials?> ParseAsync(HttpContext context)
        {
            var clientSecretValue = context.Request.Form["client_secret"].FirstOrDefault();
            if (!string.IsNullOrEmpty(clientSecretValue))
            {
                var clientSecretParsed = new ClientCredentials("HASH", clientSecretValue);
                return Task.FromResult<ClientCredentials?>(clientSecretParsed);
            }

            return Task.FromResult<ClientCredentials?>(null);
        }
    }
}
