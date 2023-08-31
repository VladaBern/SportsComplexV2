using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository.Interfaces
{
    public interface IDisciplineRepository
    {
        Task<IEnumerable<Discipline>> GetDisciplinesAsync();
        Task<Discipline> GetDisciplineAsync(int id);
        Task<int> CreateDisciplineAsync(Discipline discipline);
        Task<bool> UpdateDisciplineAsync(Discipline discipline);
        Task<bool> DeleteDisciplineAsync(int id);
    }
}
