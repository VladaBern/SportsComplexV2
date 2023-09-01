using AutoMapper;
using SportsComplex.Repository.Interfaces;
using SportsComplex.Repository.Interfaces.Models;
using SportsComplex.Services.Interfaces;
using SportsComplex.Services.Interfaces.DTO;
using SportsComplex.Services.Exceptions;
using SportsComplex.Services.Validators;

namespace SportsComplex.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository repository;
        private readonly IMapper mapper;
        private readonly IIdValidator idValidator;
        private readonly IClientValidator clientValidator;

        public ClientService(IClientRepository repository, IMapper mapper, IIdValidator idValidator, IClientValidator clientValidator)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.idValidator = idValidator ?? throw new ArgumentNullException(nameof(idValidator));
            this.clientValidator = clientValidator ?? throw new ArgumentNullException(nameof(clientValidator));
        }

        public async Task<IEnumerable<ClientDto>> GetClientsAsync()
        {
            return mapper.Map<IEnumerable<Client>, IEnumerable<ClientDto>>(await repository.GetClientsAsync());
        }

        public async Task<ClientDto> GetClientAsync(int id)
        {
            idValidator.Validate(id);
            var client = await repository.GetClientAsync(id);
            if (client == null)
                throw new EntityNotFoundException("Client not found");

            return mapper.Map<Client, ClientDto>(client);
        }

        public async Task<ClientDto> CreateClientAsync(ClientDto client)
        {
            await clientValidator.ValidateAsync(client);
            var clientId = await repository.CreateClientAsync(mapper.Map<ClientDto, Client>(client));
            if (clientId == -1)
                throw new EntityNotCreatedException("Client not created");

            client.Id = clientId;

            return client;
        }

        public async Task<ClientDto> UpdateClientAsync(int id, ClientDto client)
        {
            idValidator.Validate(id);
            await clientValidator.ValidateAsync(client);
            client.Id = id;
            var updated = await repository.UpdateClientAsync(mapper.Map<ClientDto, Client>(client));
            if (!updated)
                throw new EntityNotFoundException("Client not found");

            return client;
        }

        public async Task DeleteClientAsync(int id)
        {
            idValidator.Validate(id);
            var deleted = await repository.DeleteClientAsync(id);
            if (!deleted)
                throw new EntityNotFoundException("Client not found");
        }
    }
}
