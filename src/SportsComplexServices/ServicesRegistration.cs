using Microsoft.Extensions.DependencyInjection;
using SportsComplex.Services.Interfaces;
using SportsComplex.Services.Validators;

namespace SportsComplex.Services
{
    public static class ServicesRegistration
    {
        public static void AddServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IIdValidator, IdValidator>();
            serviceCollection.AddSingleton<IDisciplineValidator, DisciplineValidator>();
            serviceCollection.AddTransient<ICoachValidator, CoachValidator>();
            serviceCollection.AddTransient<IClientValidator, ClientValidator>();
            serviceCollection.AddTransient<IDisciplineService, DisciplineService>();
            serviceCollection.AddTransient<ICoachService, CoachService>();
            serviceCollection.AddTransient<IClientService, ClientService>();

            serviceCollection.AddAutoMapper(typeof(ServicesRegistration));
        }
    }
}
