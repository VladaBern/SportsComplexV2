using SportsComplex.Services.Interfaces.Models;

namespace SportsComplex.Services.Interfaces
{
    public interface ICoachService
    {
        IEnumerable<Coach> GetCoaches();
        Coach GetCoach(int id);
        Coach CreateCoach(Coach coach);
        Coach UpdateCoach(int id, Coach coach);
        void DeleteCoach(int id);
    }
}
