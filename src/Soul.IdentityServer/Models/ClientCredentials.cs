namespace Soul.IdentityServer.Models
{
    public class ClientCredentials
    {
        public string Type { get; set; }
        public object Value { get; set; }

        public ClientCredentials(string type, object value)
        {
            Type = type;
            Value = value;
        }
    }
}
