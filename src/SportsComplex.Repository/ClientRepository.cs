using SportsComplex.Repository.Interfaces;
using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository
{
    internal class ClientRepository : IClientRepository
    {
        private SportsComplexDbContext dbContext;

        public ClientRepository(SportsComplexDbContext context)
        {
            dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Client> GetClients()
        {
            return dbContext.Clients.ToList();
        }

        public Client GetClient(int id)
        {
            return dbContext.Clients.FirstOrDefault(x => x.Id == id);
        }

        public int CreateClient(Client client)
        {
            dbContext.Clients.Add(client);
            dbContext.SaveChanges();
            return client.Id;
        }

        public bool UpdateClient(Client client)
        {
            dbContext.Update(client);
            return dbContext.SaveChanges() == 1;
        }

        public bool DeleteClient(int id)
        {
            var client = dbContext.Clients.FirstOrDefault(x => x.Id == id);

            if (client == null)
                return false;

            dbContext.Clients.Remove(client);
            return dbContext.SaveChanges() == 1;
        }
    }
}
