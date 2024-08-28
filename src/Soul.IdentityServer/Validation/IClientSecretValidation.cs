using Soul.IdentityModel;

namespace Soul.IdentityServer.Validation
{
    public interface IClientSecretValidator
    {
        Task<bool> ValidateAsync(Client client, ClientSecretParsed secretParsed);
    }
}
