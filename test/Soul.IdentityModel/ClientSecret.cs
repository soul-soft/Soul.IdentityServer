using System;

namespace Soul.IdentityModel
{
    public class ClientSecret
    {
        public string Value { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Expires { get; set; }
        public string Type { get; set; } 
    }
}
