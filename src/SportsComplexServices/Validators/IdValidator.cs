using SportsComplex.Services.Validators.Exceptions;

namespace SportsComplex.Services.Validators
{
    public class IdValidator : IIdValidator
    {
        public void Validate(int id)
        {
            if (id < 1)
                throw new ValidationException("Id must be greater than zero");
        }
    }
}
