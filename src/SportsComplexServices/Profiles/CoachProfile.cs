using AutoMapper;
using SportsComplex.Repository.Interfaces.Models;
using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Profiles
{
    public class CoachProfile : Profile
    {
        public CoachProfile()
        {
            CreateMap<CoachDto, Coach>();
            CreateMap<Coach, CoachDto>();
        }
    }
}
