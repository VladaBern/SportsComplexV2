using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Interfaces
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetClientsAsync();
        Task<ClientDto> GetClientAsync(int id);
        Task<ClientDto> CreateClientAsync(ClientDto client);
        Task<ClientDto> UpdateClientAsync(int id, ClientDto client);
        Task DeleteClientAsync(int id);
    }
}
