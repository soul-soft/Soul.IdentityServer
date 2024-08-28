namespace Soul.IdentityModel
{
    public class ApiScope : IScope
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }

        protected ApiScope() { }

        public ApiScope(string name, string displayName = null, string description = null)
        {
            Name = name;
            DisplayName = displayName;
            Description = description;
        }
    }
}
