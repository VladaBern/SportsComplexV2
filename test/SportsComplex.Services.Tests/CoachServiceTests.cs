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
    public class CoachServiceTests
    {
        private CoachService underTest;
        private ICoachRepository coachRepository;
        private IMapper mapper;
        private IIdValidator idValidator;
        private ICoachValidator coachValidator;
        private Fixture fixture;

        public CoachServiceTests()
        {
            coachRepository = Substitute.For<ICoachRepository>();
            mapper = Substitute.For<IMapper>();
            idValidator = Substitute.For<IIdValidator>();
            coachValidator = Substitute.For<ICoachValidator>();
            underTest = new CoachService(coachRepository, mapper, idValidator, coachValidator);
            fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        [Fact]
        public async Task CreateCoachAsync_When_Coach_Not_Created_Throw_Exception()
        {
            var coach = fixture.Create<Coach>();
            var coachDto = fixture.Create<CoachDto>();
            coachRepository.CreateCoachAsync(coach).Returns(-1);
            mapper.Map<CoachDto, Coach>(coachDto).Returns(coach);

            var exception = await Assert.ThrowsAsync<EntityNotCreatedException>(() => underTest.CreateCoachAsync(coachDto));

            Assert.Equal("Coach not created", exception.Message);
        }

        [Fact]
        public async Task CreateCoachAsync_Should_Return_Coach()
        {
            var coach = fixture.Create<Coach>();
            var coachDto = fixture.Create<CoachDto>();
            coachRepository.CreateCoachAsync(coach).Returns(coachDto.Id);
            mapper.Map<CoachDto, Coach>(coachDto).Returns(coach);

            var result = await underTest.CreateCoachAsync(coachDto);

            Assert.Equal(coachDto.Id, result.Id);
        }

        [Fact]
        public async Task UpdateCoachAsync_When_Coach_Not_Exist_Throw_Exception()
        {
            int id = fixture.Create<int>();
            var coach = fixture.Create<Coach>();
            coach.Id = id;
            var coachDto = fixture.Create<CoachDto>();
            coachRepository.UpdateCoachAsync(coach).Returns(false);
            mapper.Map<CoachDto, Coach>(coachDto).Returns(coach);

            var exception = await Assert.ThrowsAsync<EntityNotFoundException>(() => underTest.UpdateCoachAsync(id, coachDto));

            Assert.Equal("Coach not found", exception.Message);
        }
    }
}
