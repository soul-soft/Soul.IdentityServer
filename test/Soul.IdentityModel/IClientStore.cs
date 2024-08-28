using System.Threading.Tasks;

namespace Soul.IdentityModel
{
    public interface IClientStore
    {
        Task<Client> FindClientByIdAsync(string clientId);
    }
}
