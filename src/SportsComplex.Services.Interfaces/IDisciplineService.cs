using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Interfaces
{
    public interface IDisciplineService
    {
        IEnumerable<DisciplineDto> GetDisciplines();
        DisciplineDto GetDiscipline(int id);
        DisciplineDto CreateDiscipline(DisciplineDto discipline);
        DisciplineDto UpdateDiscipline(int id, DisciplineDto discipline);
        void DeleteDiscipline(int id);
    }
}
