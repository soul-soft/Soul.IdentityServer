using System.Collections.Generic;

namespace Soul.IdentityModel
{
    public class Client
    {
        public string ClientId { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public ICollection<string> AllowedScopes { get; set; }

        public ICollection<string> AllowedGrantTypes { get; set; }

        public ICollection<ClientSecret> ClientSecrets { get; set; }

        protected Client() { }

        public Client(string clientId, string displayName = null, string description = null)
        {
            ClientId = clientId;
            DisplayName = displayName;
            Description = description;
        }
    }
}
