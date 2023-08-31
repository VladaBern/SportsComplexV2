using AutoMapper;
using SportsComplex.Repository.Interfaces.Models;
using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<ClientDto, Client>();
            CreateMap<Client, ClientDto>();
        }
    }
}
