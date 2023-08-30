using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository.Interfaces
{
    public interface IDisciplineRepository
    {
        IEnumerable<Discipline> GetDisciplines();
        Discipline GetDiscipline(int id);
        int CreateDiscipline(Discipline discipline);
        bool UpdateDiscipline(Discipline discipline);
        bool DeleteDiscipline(int id);
    }
}
