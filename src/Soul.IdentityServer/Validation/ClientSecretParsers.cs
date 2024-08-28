using Microsoft.AspNetCore.Http;

namespace Soul.IdentityServer.Validation
{
    internal class ClientSecretParsers
    {
        private readonly IEnumerable<IClientSecretParser> _parsers;

        public ClientSecretParsers(IEnumerable<IClientSecretParser> parsers)
        {
            _parsers = parsers;
        }

        public Task<ClientSecretParsed?> ParseAsync(HttpContext context)
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
