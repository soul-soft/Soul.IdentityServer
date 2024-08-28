using System.Collections.Generic;

namespace Soul.IdentityModel
{
    public class ApiResource : IResource
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public List<string> Scopes { get; set; } = new List<string>();

        protected ApiResource() { }

        public ApiResource(string name, string displayName = null, string description = null)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
        }
    }
}
