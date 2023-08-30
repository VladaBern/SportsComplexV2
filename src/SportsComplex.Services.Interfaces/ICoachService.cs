using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Interfaces
{
    public interface ICoachService
    {
        IEnumerable<CoachDto> GetCoaches();
        CoachDto GetCoach(int id);
        CoachDto CreateCoach(CoachDto coach);
        CoachDto UpdateCoach(int id, CoachDto coach);
        void DeleteCoach(int id);
    }
}
