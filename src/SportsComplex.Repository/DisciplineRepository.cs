using SportsComplex.Repository.Interfaces;
using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private SportsComplexDbContext dbContext;

        public DisciplineRepository(SportsComplexDbContext context)
        {
            dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Discipline> GetDisciplines()
        {
            return dbContext.Disciplines.ToList();
        }

        public Discipline GetDiscipline(int id)
        {
            return dbContext.Disciplines.FirstOrDefault(x => x.Id == id);
        }

        public int CreateDiscipline(Discipline discipline)
        {
            dbContext.Disciplines.Add(discipline);
            dbContext.SaveChanges();
            return discipline.Id;
        }

        public bool UpdateDiscipline(Discipline discipline)
        {
            dbContext.Update(discipline);
            return dbContext.SaveChanges() == 1;
        }

        public bool DeleteDiscipline(int id)
        {
            var disc = dbContext.Disciplines.FirstOrDefault(x => x.Id == id);

            if (disc == null)
                return false;

            dbContext.Disciplines.Remove(disc);
            return dbContext.SaveChanges() == 1;
        }
    }
}
