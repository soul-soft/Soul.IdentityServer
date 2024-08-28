using Microsoft.Extensions.DependencyInjection;

namespace Soul.IdentityServer.Hosting
{
    public class IdentityServerBuilder
    {
        public IServiceCollection Services { get; private set; }

        public IdentityServerBuilder(IServiceCollection services)
        {
            Services = services;
        }

        public IdentityServerBuilder ConfigureOptions(Action<IdentityServerOptions> configureOptions)
        {
            Services.Configure(configureOptions);
            return this;
        }

        public IdentityServerBuilder AddEndpointHandler<TEndpointHandler>(string path)
            where TEndpointHandler : class, IEndpointHandler
        {
            Services.AddTransient<TEndpointHandler>();
            Services.AddSingleton(new EndpointInfo(typeof(TEndpointHandler), path));
            return this;
        }

    }
}
