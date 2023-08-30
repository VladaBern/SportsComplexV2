using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClient(int id);
        int CreateClient(Client client);
        bool UpdateClient(int id, Client client);
        bool DeleteClient(int id);
    }
}
