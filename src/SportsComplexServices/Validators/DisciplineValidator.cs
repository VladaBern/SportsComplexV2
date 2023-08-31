using SportsComplex.Services.Interfaces.DTO;
using SportsComplex.Services.Validators.Exceptions;

namespace SportsComplex.Services.Validators
{
    public class DisciplineValidator : IDisciplineValidator
    {
        public void Validate(DisciplineDto discipline)
        {
            if (discipline == null)
                throw new ValidationException("Discipline shouldn't be null");
            if (string.IsNullOrWhiteSpace(discipline.Name))
                throw new ValidationException("Name cannot be empty");
            if (discipline.Name.Length < 3)
                throw new ValidationException("Name must be longer than 3 symbols");
            if (discipline.Name.Length > 50)
                throw new ValidationException("Name must be shorter than 50 symbols");
        }
    }
}
