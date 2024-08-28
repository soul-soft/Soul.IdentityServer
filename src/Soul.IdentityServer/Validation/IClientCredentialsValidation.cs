using Soul.IdentityModel;
using Soul.IdentityServer.Models;

namespace Soul.IdentityServer.Validation
{
    public interface IClientSecretValidator
    {
        Task<bool> ValidateAsync(Client client, ClientCredentials secretParsed);
    }
}
