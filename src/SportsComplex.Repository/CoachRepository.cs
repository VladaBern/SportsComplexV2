using SportsComplex.Repository.Interfaces;
using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository
{
    public class CoachRepository : ICoachRepository
    {
        private SportsComplexDbContext dbContext;

        public CoachRepository(SportsComplexDbContext context)
        {
            dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Coach> GetCoaches()
        {
            return dbContext.Coaches.ToList();
        }

        public Coach GetCoach(int id)
        {
            return dbContext.Coaches.FirstOrDefault(x => x.Id == id);
        }

        public int CreateCoach(Coach coach)
        {
            dbContext.Coaches.Add(coach);
            dbContext.SaveChanges();
            return coach.Id;
        }

        public bool UpdateCoach(Coach coach)
        {
            dbContext.Update(coach);
            return dbContext.SaveChanges() == 1;
        }

        public bool DeleteCoach(int id)
        {
            var coach = dbContext.Coaches.FirstOrDefault(x => x.Id == id);

            if (coach == null)
                return false;

            dbContext.Coaches.Remove(coach);
            return dbContext.SaveChanges() == 1;
        }        
    }
}
