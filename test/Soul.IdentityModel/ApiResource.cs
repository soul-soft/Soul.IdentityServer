using System.Collections.Generic;

namespace Soul.IdentityModel
{
    public class ApiResource : IResource
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<string> Scopes { get; set; } = new List<string>();
    }
}
