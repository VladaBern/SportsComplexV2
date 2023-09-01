using AutoFixture;
using AutoMapper;
using NSubstitute;
using SportsComplex.Repository.Interfaces;
using SportsComplex.Repository.Interfaces.Models;
using SportsComplex.Services.Exceptions;
using SportsComplex.Services.Interfaces.DTO;
using SportsComplex.Services.Validators;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace SportsComplex.Services.Tests
{
    public class DisciplineServiceTests
    {
        private DisciplineService underTest;
        private IDisciplineRepository disciplineRepository;
        private IMapper mapper;
        private IIdValidator idValidator;
        private IDisciplineValidator disciplineValidator;
        private Fixture fixture;

        public DisciplineServiceTests()
        {
            disciplineRepository = Substitute.For<IDisciplineRepository>();
            mapper = Substitute.For<IMapper>();
            idValidator = Substitute.For<IIdValidator>();
            disciplineValidator = Substitute.For<IDisciplineValidator>();
            underTest = new DisciplineService(disciplineRepository, mapper, idValidator, disciplineValidator);
            fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task GetDisciplinesAsync_Should_Return_Collection()
        {
            var disciplinesDto = fixture.CreateMany<DisciplineDto>();
            var disciplines = fixture.CreateMany<Discipline>();
            disciplineRepository.GetDisciplinesAsync().Returns(disciplines);
            mapper.Map<IEnumerable<Discipline>, IEnumerable<DisciplineDto>>(disciplines).Returns(disciplinesDto);

            var result = await underTest.GetDisciplinesAsync();

            Assert.Equal(disciplinesDto, result);
        }

        [Fact]
        public async Task GetDisciplineAsync_When_Discipline_Not_Exist_Throw_Exception()
        {
            int id = fixture.Create<int>();
            disciplineRepository.GetDisciplineAsync(id).Returns((Discipline)null);

            var exception = await Assert.ThrowsAsync<EntityNotFoundException>(() => underTest.GetDisciplineAsync(id));

            Assert.Equal("Discipline not found", exception.Message);
        }

        [Fact]
        public async Task GetDisciplineAsync_Should_Return_Discipline()
        {
            var id = fixture.Create<int>();
            var disciplineDto = fixture.Create<DisciplineDto>();
            disciplineDto.Id = id;
            var discipline = fixture.Create<Discipline>();
            discipline.Id = id;
            disciplineRepository.GetDisciplineAsync(id).Returns(discipline);
            mapper.Map<Discipline, DisciplineDto>(discipline).Returns(disciplineDto);

            var result = await underTest.GetDisciplineAsync(id);

            Assert.Equal(disciplineDto, result);
        }
    }
}
