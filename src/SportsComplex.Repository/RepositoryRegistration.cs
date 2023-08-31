using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportsComplex.Repository.Interfaces;

namespace SportsComplex.Repository
{
    public static class RepositoryRegistration
    {
        public static void AddRepositories(this IServiceCollection serviceCollection, string connection)
        {
            serviceCollection.AddDbContext<SportsComplexDbContext>(options => options.UseSqlServer(connection));

            serviceCollection.AddTransient<IDisciplineRepository, DisciplineRepository>();
            serviceCollection.AddTransient<ICoachRepository, CoachRepository>();
            serviceCollection.AddTransient<IClientRepository, ClientRepository>();
        }
    }
}
