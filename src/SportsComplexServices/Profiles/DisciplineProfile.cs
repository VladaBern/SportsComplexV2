using AutoMapper;
using SportsComplex.Repository.Interfaces.Models;
using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Profiles
{
    public class DisciplineProfile : Profile
    {
        public DisciplineProfile()
        {
            CreateMap<DisciplineDto, Discipline>();
            CreateMap<Discipline, DisciplineDto>();
        }
    }
}
