using AutoMapper;
using SportsComplex.Repository.Interfaces;
using SportsComplex.Repository.Interfaces.Models;
using SportsComplex.Services.Interfaces;
using SportsComplex.Services.Interfaces.DTO;
using SportsComplex.Services.Exceptions;
using SportsComplex.Services.Validators;

namespace SportsComplex.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly IDisciplineRepository repository;
        private readonly IMapper mapper;
        private readonly IIdValidator idValidator;
        private readonly IDisciplineValidator disciplineValidator;

        public DisciplineService(IDisciplineRepository repository, IMapper mapper, IIdValidator idValidator, IDisciplineValidator disciplineValidator)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            this.idValidator = idValidator ?? throw new ArgumentNullException(nameof(idValidator));
            this.disciplineValidator = disciplineValidator ?? throw new ArgumentNullException(nameof(disciplineValidator));
        }

        public async Task<IEnumerable<DisciplineDto>> GetDisciplinesAsync()
        {
            return mapper.Map<IEnumerable<Discipline>, IEnumerable<DisciplineDto>>(await repository.GetDisciplinesAsync());
        }

        public async Task<DisciplineDto> GetDisciplineAsync(int id)
        {
            idValidator.Validate(id);
            var disc = await repository.GetDisciplineAsync(id);
            if (disc == null)
                throw new EntityNotFoundException("Discipline not found");

            return mapper.Map<Discipline, DisciplineDto>(disc);
        }

        public async Task<DisciplineDto> CreateDisciplineAsync(DisciplineDto discipline)
        {
            disciplineValidator.Validate(discipline);
            var discId = await repository.CreateDisciplineAsync(mapper.Map<DisciplineDto, Discipline>(discipline));
            if (discId == -1)
                throw new EntityNotCreatedException("Discipline not created");

            discipline.Id = discId;

            return discipline;
        }

        public async Task<DisciplineDto> UpdateDisciplineAsync(int id, DisciplineDto discipline)
        {
            idValidator.Validate(id);
            disciplineValidator.Validate(discipline);
            discipline.Id = id;
            var updated = await repository.UpdateDisciplineAsync(mapper.Map<DisciplineDto, Discipline>(discipline));
            if (!updated)
                throw new EntityNotFoundException("Discipline not found");

            return discipline;
        }

        public async Task DeleteDisciplineAsync(int id)
        {
            idValidator.Validate(id);
            var deleted = await repository.DeleteDisciplineAsync(id);
            if (!deleted)
                throw new EntityNotFoundException("Discipline not found");
        }
    }
}
