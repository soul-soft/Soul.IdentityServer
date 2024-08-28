using System.Collections.Generic;

namespace Soul.IdentityModel
{
    public class ApiResource : Resource
    {
        public List<string> Scopes { get; set; } = new List<string>();
    }
}
