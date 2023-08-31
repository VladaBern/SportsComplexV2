using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Interfaces
{
    public interface ICoachService
    {
        Task<IEnumerable<CoachDto>> GetCoachesAsync();
        Task<CoachDto> GetCoachAsync(int id);
        Task<CoachDto> CreateCoachAsync(CoachDto coach);
        Task<CoachDto> UpdateCoachAsync(int id, CoachDto coach);
        Task DeleteCoachAsync(int id);
    }
}
