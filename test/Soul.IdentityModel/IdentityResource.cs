using System.Collections.Generic;
using System.Security.Claims;

namespace Soul.IdentityModel
{
    public class IdentityResource : Resource
    {
        public List<Claim> UserClaims { get; set; } = new List<Claim>();
    }
}
