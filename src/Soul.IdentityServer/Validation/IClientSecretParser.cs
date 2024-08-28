using Microsoft.AspNetCore.Http;

namespace Soul.IdentityServer.Validation
{
    public class ClientSecretParsed
    {
        public string Type { get; set; }
        public object Value { get; set; }

        public ClientSecretParsed(string type, object value)
        {
            Type = type;
            Value = value;
        }
    }

    public interface IClientSecretParser
    {
        Task<ClientSecretParsed?> ParseAsync(HttpContext context);
    }
}
