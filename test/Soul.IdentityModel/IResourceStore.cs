using System.Threading.Tasks;

namespace Soul.IdentityModel
{
    public interface IResourceStore
    {
        Task<Resources> GetResourcesByScopeAsync(string[] scopes);
    }
}
