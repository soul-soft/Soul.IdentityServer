using System.Collections.Generic;
using System.Security.Claims;

namespace Soul.IdentityModel
{
    public class IdentityResource : IResource, IScope
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<Claim> UserClaims { get; set; } = new List<Claim>();
    }
}
