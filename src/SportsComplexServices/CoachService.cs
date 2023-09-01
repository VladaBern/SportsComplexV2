using AutoMapper;
using SportsComplex.Repository.Interfaces;
using SportsComplex.Repository.Interfaces.Models;
using SportsComplex.Services.Interfaces;
using SportsComplex.Services.Interfaces.DTO;
using SportsComplex.Services.Exceptions;
using SportsComplex.Services.Validators;

namespace SportsComplex.Services
{
    public class CoachService :ICoachService
    {
        private readonly ICoachRepository repository;
        private readonly IMapper mapper;
        private readonly IIdValidator idValidator;
        private readonly ICoachValidator coachValidator;

        public CoachService(ICoachRepository repository, IMapper mapper, IIdValidator idValidator, ICoachValidator coachValidator)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.idValidator = idValidator ?? throw new ArgumentNullException(nameof(idValidator));
            this.coachValidator = coachValidator ?? throw new ArgumentNullException(nameof(coachValidator));
        }

        public async Task<IEnumerable<CoachDto>> GetCoachesAsync()
        {
            return mapper.Map<IEnumerable<Coach>, IEnumerable<CoachDto>>(await repository.GetCoachesAsync());
        }

        public async Task<CoachDto> GetCoachAsync(int id)
        {
            idValidator.Validate(id);
            var coach = await repository.GetCoachAsync(id);
            if (coach == null)
                throw new EntityNotFoundException("Coach not found");

            return mapper.Map<Coach, CoachDto>(coach);
        }

        public async Task<CoachDto> CreateCoachAsync(CoachDto coach)
        {
            await coachValidator.ValidateAsync(coach);
            var coachId = await repository.CreateCoachAsync(mapper.Map<CoachDto, Coach>(coach));
            if (coachId == -1)
                throw new EntityNotCreatedException("Coach not created");

            coach.Id = coachId;

            return coach;
        }

        public async Task<CoachDto> UpdateCoachAsync(int id, CoachDto coach)
        {
            idValidator.Validate(id);
            await coachValidator.ValidateAsync(coach);
            coach.Id = id;
            var updated = await repository.UpdateCoachAsync(mapper.Map<CoachDto, Coach>(coach));
            if (!updated)
                throw new EntityNotFoundException("Coach not found");

            return coach;
        }

        public async Task DeleteCoachAsync(int id)
        {
            idValidator.Validate(id);
            var deleted = await repository.DeleteCoachAsync(id);
            if (!deleted)
                throw new EntityNotFoundException("Coach not found");
        }
    }
}
