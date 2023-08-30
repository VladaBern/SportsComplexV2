using SportsComplex.Services.Interfaces.Models;

namespace SportsComplex.Services.Interfaces
{
    public interface IDisciplineService
    {
        IEnumerable<Discipline> GetDisciplines();
        Discipline GetDiscipline(int id);
        Discipline CreateDiscipline(Discipline discipline);
        Discipline UpdateDiscipline(int id, Discipline discipline);
        void DeleteDiscipline(int id);
    }
}
