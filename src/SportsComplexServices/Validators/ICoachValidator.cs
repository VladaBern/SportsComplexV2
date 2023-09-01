using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Validators
{
    public interface ICoachValidator
    {
        Task ValidateAsync(CoachDto coach);
    }
}
