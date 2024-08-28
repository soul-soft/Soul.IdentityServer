using Microsoft.AspNetCore.Http;
using Soul.IdentityServer.Models;

namespace Soul.IdentityServer.Validation
{
    internal class ClientCredentialstParsers
    {
        private readonly IEnumerable<IClientCredentialsParser> _parsers;

        public ClientCredentialstParsers(IEnumerable<IClientCredentialsParser> parsers)
        {
            _parsers = parsers;
        }

        public Task<ClientCredentials?> ParseAsync(HttpContext context)
        {
            foreach (var item in _parsers)
            {
                var clientSecretParsed = item.ParseAsync(context);
                if (clientSecretParsed != null)
                {
                    return clientSecretParsed;
                }
            }

            throw new NotImplementedException();
        }
    }
}
