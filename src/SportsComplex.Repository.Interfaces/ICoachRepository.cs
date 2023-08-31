using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository.Interfaces
{
    public interface ICoachRepository
    {
        Task<IEnumerable<Coach>> GetCoachesAsync();
        Task<Coach> GetCoachAsync(int id);
        Task<int> CreateCoachAsync(Coach coach);
        Task<bool> UpdateCoachAsync(Coach coach);
        Task<bool> DeleteCoachAsync(int id);
    }
}
