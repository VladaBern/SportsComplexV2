using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Interfaces
{
    public interface IDisciplineService
    {
        Task<IEnumerable<DisciplineDto>> GetDisciplinesAsync();
        Task<DisciplineDto> GetDisciplineAsync(int id);
        Task<DisciplineDto> CreateDisciplineAsync(DisciplineDto discipline);
        Task<DisciplineDto> UpdateDisciplineAsync(int id, DisciplineDto discipline);
        Task DeleteDisciplineAsync(int id);
    }
}
