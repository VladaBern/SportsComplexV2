using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository.Interfaces
{
    public interface ICoachRepository
    {
        IEnumerable<Coach> GetCoaches();
        Coach GetCoach(int id);
        int CreateCoach(Coach coach);
        bool UpdateCoach(Coach coach);
        bool DeleteCoach(int id);
    }
}
