using System.Collections.Generic;

namespace Soul.IdentityModel
{
    public class Client
    {
        public string ClientId { get; set; }

        public ICollection<string> AllowedScopes { get; set; }

        public ICollection<string> AllowedGrantTypes { get; set; }

        public ICollection<ClientSecret> ClientSecrets { get; set; }
    }
}
