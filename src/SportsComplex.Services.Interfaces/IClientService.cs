using SportsComplex.Services.Interfaces.Models;

namespace SportsComplex.Services.Interfaces
{
    internal interface IClientService
    {
        IEnumerable<Client> GetClients();
        Client GetClient(int id);
        Client CreateClient(Client client);
        Client UpdateClient(int id, Client client);
        void DeleteClient(int id);
    }
}
