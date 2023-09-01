using SportsComplex.Repository.Interfaces;
using SportsComplex.Services.Interfaces.DTO;
using SportsComplex.Services.Validators.Exceptions;

namespace SportsComplex.Services.Validators
{
    public class CoachValidator : ICoachValidator
    {
        private readonly IDisciplineRepository discRepository;

        public CoachValidator(IDisciplineRepository discRepository)
        {
            this.discRepository = discRepository ?? throw new ArgumentNullException(nameof(discRepository));
        }

        public async Task ValidateAsync(CoachDto coach)
        {
            if (coach == null)
                throw new ValidationException("Coach shouldn't be null");
            if (string.IsNullOrWhiteSpace(coach.Name))
                throw new ValidationException("Name cannot be empty");
            if (coach.Name.Length < 3)
                throw new ValidationException("Name must be longer than 3 symbols");
            if (coach.Name.Length > 40)
                throw new ValidationException("Name must be shorter than 40 symbols");
            if (string.IsNullOrWhiteSpace(coach.Surname))
                throw new ValidationException("Surname cannot be empty");
            if (coach.Surname.Length < 3)
                throw new ValidationException("Surname must be longer than 3 symbols");
            if (coach.Surname.Length > 50)
                throw new ValidationException("Surname must be shorter than 50");
            if (coach.DateOfBirth.Year < 1960)
                throw new ValidationException("Year of birth must be greater than 1960");
            if (coach.DateOfBirth.Year > DateTime.Now.Year - 18)
                throw new ValidationException("Year of birth must be less than " + (DateTime.Now.Year - 18));
            if (string.IsNullOrWhiteSpace(coach.Phone))
                throw new ValidationException("Phone cannot be empty");
            if (coach.Phone.Length != 11)
                throw new ValidationException("Phone must has 11 symbols");
            if (string.IsNullOrWhiteSpace(coach.IdentityNumber))
                throw new ValidationException("Identity number cannot be empty");
            if (coach.IdentityNumber.Length != 11)
                throw new ValidationException("Identity number must has 11 symbols");
            if (coach.DisciplineId < 1)
                throw new ValidationException("Discipline id must be greater than zero");
            var disc = await discRepository.GetDisciplineAsync(coach.DisciplineId);
            if (disc == null)
                throw new ValidationException("Discipline id doesn't exist");
        }
    }
}
