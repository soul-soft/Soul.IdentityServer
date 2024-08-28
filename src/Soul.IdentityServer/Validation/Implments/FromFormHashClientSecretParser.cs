using Microsoft.AspNetCore.Http;

namespace Soul.IdentityServer.Validation
{
    internal class FromFormHashClientSecretParser : IClientSecretParser
    {
        public Task<ClientSecretParsed?> ParseAsync(HttpContext context)
        {
            var clientSecretValue = context.Request.Form["client_secret"].FirstOrDefault();
            if (!string.IsNullOrEmpty(clientSecretValue))
            {
                var clientSecretParsed = new ClientSecretParsed("HASH", clientSecretValue);
                return Task.FromResult<ClientSecretParsed?>(clientSecretParsed);
            }

            return Task.FromResult<ClientSecretParsed?>(null);
        }
    }
}
