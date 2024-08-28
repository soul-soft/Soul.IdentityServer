using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soul.IdentityModel;

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

        public IdentityServerBuilder AddClientStore<TClientStore>()
           where TClientStore : class, IClientStore
        {
            Services.TryAddTransient<IClientStore, TClientStore>();
            return this;
        }

        public IdentityServerBuilder AddClientStore<TClientStore>(Func<IServiceProvider, TClientStore> clients)
          where TClientStore : class, IClientStore
        {
            Services.TryAddTransient<IClientStore>(clients);
            return this;
        }

        public IdentityServerBuilder AddResourceStore<TResourceStore>()
            where TResourceStore : class, IResourceStore
        {
            Services.TryAddTransient<IResourceStore, TResourceStore>();
            return this;
        }

        public IdentityServerBuilder AddResourceStore<TResourceStore>(Func<IServiceProvider, TResourceStore> resources)
          where TResourceStore : class, IResourceStore
        {
            Services.TryAddTransient<IResourceStore>(resources);
            return this;
        }

    }
}
