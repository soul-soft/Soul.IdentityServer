using Soul.IdentityModel;

namespace Soul.IdentityServer.Stores
{
    internal class MemoryClientStore : IClientStore
    {
        private readonly IEnumerable<Client> _clients;

        public MemoryClientStore(IEnumerable<Client> clients)
        {
            _clients = clients;
        }

        public Task<Client> FindClientByIdAsync(string clientId)
        {
            var client = _clients.Where(a => a.ClientId == clientId).First();
            return Task.FromResult(client);
        }
    }
}
