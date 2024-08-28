namespace Soul.IdentityModel
{
    public interface IScope
    {
        string Name { get; set; }
        string DisplayName { get; set; }
        string Description { get; set; }
    }
}
