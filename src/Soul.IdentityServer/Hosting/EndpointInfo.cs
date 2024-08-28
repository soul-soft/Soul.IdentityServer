namespace Soul.IdentityServer.Hosting
{
    internal class EndpointInfo
    {
        public Type Type { get; }
        public string Path { get; }

        public EndpointInfo(Type type, string path)
        {
            Type = type;
            Path = path;
        }
    }
}
