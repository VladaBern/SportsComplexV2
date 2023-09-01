using AutoFixture;
using AutoMapper;
using NSubstitute;
using SportsComplex.Repository.Interfaces;
using SportsComplex.Repository.Interfaces.Models;
using SportsComplex.Services.Exceptions;
using SportsComplex.Services.Interfaces.DTO;
using SportsComplex.Services.Validators;
using System.Threading.Tasks;
using Xunit;

namespace SportsComplex.Services.Tests
{
    public class ClientServiceTests
    {
        private ClientService underTest;
        private IClientRepository clientRepository;
        private IMapper mapper;
        private IIdValidator idValidator;
        private IClientValidator clientValidator;
        private Fixture fixture;

        public ClientServiceTests()
        {
            clientRepository = Substitute.For<IClientRepository>();
            mapper = Substitute.For<IMapper>();
            idValidator = Substitute.For<IIdValidator>();
            clientValidator = Substitute.For<IClientValidator>();
            underTest = new ClientService(clientRepository, mapper, idValidator, clientValidator);
            fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task UpdateClientAsync_Should_Return_Client()
        {
            int id = fixture.Create<int>();
            var client = fixture.Create<Client>();
            client.Id = id;
            var clientDto = fixture.Create<ClientDto>();
            clientRepository.UpdateClientAsync(client).Returns(true);
            mapper.Map<ClientDto, Client>(clientDto).Returns(client);

            var result = await underTest.UpdateClientAsync(id, clientDto);

            Assert.Equal(clientDto, result);
        }

        [Fact]
        public async Task DeleteClientAsync_When_Client_Not_Exist_Throw_Exception()
        {
            int id = fixture.Create<int>();
            clientRepository.DeleteClientAsync(id).Returns(false);

            var exception = await Assert.ThrowsAsync<EntityNotFoundException>(() => underTest.DeleteClientAsync(id));

            Assert.Equal("Client not found", exception.Message);
        }

        [Fact]
        public async Task DeleteClientAsync_Should_Complete()
        {
            int id = fixture.Create<int>();
            clientRepository.DeleteClientAsync(id).Returns(true);

            await underTest.DeleteClientAsync(id);
        }
    }
}
