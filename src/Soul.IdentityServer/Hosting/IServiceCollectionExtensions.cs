using Soul.IdentityServer.Hosting;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddIdentityServer(this IServiceCollection services, Action<IdentityServerBuilder> configure)
        {
            var builder = new IdentityServerBuilder(services);
            builder.AddRequiredEndpoints();
            configure(builder);
            return services;
        }
    }
}
