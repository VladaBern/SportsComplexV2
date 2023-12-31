﻿using Microsoft.EntityFrameworkCore;
using SportsComplex.Repository.Interfaces;
using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository
{
    public class DisciplineRepository : IDisciplineRepository
    {
        private readonly SportsComplexDbContext dbContext;

        public DisciplineRepository(SportsComplexDbContext context)
        {
            dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Discipline>> GetDisciplinesAsync()
        {
            return await dbContext.Disciplines.ToListAsync();
        }

        public async Task<Discipline> GetDisciplineAsync(int id)
        {
            return await dbContext.Disciplines.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> CreateDisciplineAsync(Discipline discipline)
        {
            dbContext.Disciplines.Add(discipline);
            if (await dbContext.SaveChangesAsync() == 1)
                return discipline.Id;

            return -1;
        }

        public async Task<bool> UpdateDisciplineAsync(Discipline discipline)
        {
            var disc = await dbContext.Disciplines.FirstOrDefaultAsync(x => x.Id == discipline.Id);
            if (disc == null)
                return false;
            disc.Name = discipline.Name;
            dbContext.Disciplines.Update(disc);
            return await dbContext.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteDisciplineAsync(int id)
        {
            var disc = await dbContext.Disciplines.FirstOrDefaultAsync(x => x.Id == id);

            if (disc == null)
                return false;

            dbContext.Disciplines.Remove(disc);
            return await dbContext.SaveChangesAsync() == 1;
        }
    }
}
