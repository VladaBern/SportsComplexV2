using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Interfaces
{
    public interface IClientService
    {
        IEnumerable<ClientDto> GetClients();
        ClientDto GetClient(int id);
        ClientDto CreateClient(ClientDto client);
        ClientDto UpdateClient(int id, ClientDto client);
        void DeleteClient(int id);
    }
}
