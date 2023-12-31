﻿using Microsoft.EntityFrameworkCore;
using SportsComplex.Repository.Interfaces;
using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository
{
    public class CoachRepository : ICoachRepository
    {
        private readonly SportsComplexDbContext dbContext;

        public CoachRepository(SportsComplexDbContext context)
        {
            dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Coach>> GetCoachesAsync()
        {
            return await dbContext.Coaches.ToListAsync();
        }

        public async Task<Coach> GetCoachAsync(int id)
        {
            return await dbContext.Coaches.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> CreateCoachAsync(Coach coach)
        {
            dbContext.Coaches.Add(coach);
            if (await dbContext.SaveChangesAsync() == 1)
                return coach.Id;

            return -1;
        }

        public async Task<bool> UpdateCoachAsync(Coach coach)
        {
            var coachDb = await dbContext.Coaches.FirstOrDefaultAsync(x => x.Id == coach.Id);
            if (coachDb == null)
                return false;
            coachDb.Name = coach.Name;
            coachDb.Surname = coach.Surname;
            coachDb.DateOfBirth = coach.DateOfBirth;
            coachDb.Phone = coach.Phone;
            coachDb.IdentityNumber = coach.IdentityNumber;
            coachDb.DisciplineId = coach.DisciplineId;
            dbContext.Coaches.Update(coachDb);
            return await dbContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteCoachAsync(int id)
        {
            var coach = await dbContext.Coaches.FirstOrDefaultAsync(x => x.Id == id);

            if (coach == null)
                return false;

            dbContext.Coaches.Remove(coach);
            return await dbContext.SaveChangesAsync() == 1;
        }
    }
}
