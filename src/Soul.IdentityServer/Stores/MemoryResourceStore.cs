using Soul.IdentityModel;

namespace Soul.IdentityServer.Stores
{
    internal class MemoryResourceStore : IResourceStore
    {
        private readonly IEnumerable<ApiScope> _apiScopes;
        private readonly IEnumerable<ApiResource> _apiResources;
        private readonly IEnumerable<IdentityResource> _identityResources;

        public MemoryResourceStore(
            IEnumerable<ApiScope> apiScopes,
            IEnumerable<ApiResource> apiResources,
            IEnumerable<IdentityResource> identityResources)
        {
            _apiScopes = apiScopes;
            _apiResources = apiResources;
            _identityResources = identityResources;
        }

        public Task<Resources> GetResourcesAsync(string[] scopes)
        {
            var apiResources = _apiResources
                .Where(a => a.Scopes.Any(a => scopes.Contains(a)))
                .ToList();

            var identityResources = _identityResources
                 .Where(a => scopes.Contains(a.Name))
                 .ToList();

            var resources = new Resources(apiResources, identityResources);

            return Task.FromResult(resources);
        }
    }
}
