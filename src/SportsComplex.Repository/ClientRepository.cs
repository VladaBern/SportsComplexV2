using Microsoft.EntityFrameworkCore;
using SportsComplex.Repository.Interfaces;
using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly SportsComplexDbContext dbContext;

        public ClientRepository(SportsComplexDbContext context)
        {
            dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            return await dbContext.Clients.ToListAsync();
        }

        public async Task<Client> GetClientAsync(int id)
        {
            return await dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> CreateClientAsync(Client client)
        {
            dbContext.Clients.Add(client);
            if (await dbContext.SaveChangesAsync() == 1)
                return client.Id;

            return -1;
        }

        public async Task<bool> UpdateClientAsync(Client client)
        {
            var clientDb = await dbContext.Clients.FirstOrDefaultAsync(x => x.Id == client.Id);
            if (clientDb == null)
                return false;
            clientDb.Name = client.Name;
            clientDb.Surname = client.Surname;
            clientDb.DateOfBirth = client.DateOfBirth;
            clientDb.Phone = client.Phone;
            clientDb.IdentityNumber = client.IdentityNumber;
            clientDb.CoachId = client.CoachId;
            dbContext.Clients.Update(clientDb);
            return await dbContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await dbContext.Clients.FirstOrDefaultAsync(x => x.Id == id);

            if (client == null)
                return false;

            dbContext.Clients.Remove(client);
            return await dbContext.SaveChangesAsync() == 1;
        }
    }
}
