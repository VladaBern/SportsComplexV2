using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Validators
{
    public interface ICoachValidator
    {
        void Validate(CoachDto coach);
    }
}
