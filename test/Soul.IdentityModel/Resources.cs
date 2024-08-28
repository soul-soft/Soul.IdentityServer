using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Soul.IdentityModel
{
    public class Resources : IEnumerable<IResource>
    {
        private IEnumerable<IResource> _resources;

        public Resources(
            IEnumerable<ApiScope> apiScopes,
            IEnumerable<ApiResource> apiResources,
            IEnumerable<IdentityResource> identityResources)
        {
            _resources = apiScopes.Cast<IResource>().Union(apiResources).Union(identityResources).ToList();
        }

        public IReadOnlyCollection<IScope> Scopes => ApiScopes.Cast<IScope>().Union(IdentityResources.Cast<IScope>()).ToList();

        public IReadOnlyCollection<ApiScope> ApiScopes => _resources.Where(a => a is ApiScope).Cast<ApiScope>().ToList();

        public IReadOnlyCollection<ApiResource> ApiResources => _resources.Where(a => a is ApiResource).Cast<ApiResource>().ToList();

        public IReadOnlyCollection<IdentityResource> IdentityResources => _resources.Where(a => a is IdentityResource).Cast<IdentityResource>().ToList();

        public IEnumerator<IResource> GetEnumerator()
        {
            return _resources.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_resources).GetEnumerator();
        }
    }
}
