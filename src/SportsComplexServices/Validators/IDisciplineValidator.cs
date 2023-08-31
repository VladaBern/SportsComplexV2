using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Validators
{
    public interface IDisciplineValidator
    {
        void Validate(DisciplineDto discipline);
    }
}
