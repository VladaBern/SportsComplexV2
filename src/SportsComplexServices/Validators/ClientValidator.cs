using SportsComplex.Services.Interfaces.DTO;
using SportsComplex.Services.Validators.Exceptions;

namespace SportsComplex.Services.Validators
{
    public class ClientValidator : IClientValidator
    {
        public void Validate(ClientDto client)
        {
            if (client == null)
                throw new ValidationException("Client shouldn't be null");
            if (string.IsNullOrWhiteSpace(client.Name))
                throw new ValidationException("Name cannot be empty");
            if (client.Name.Length < 3)
                throw new ValidationException("Name must be longer than 3 symbols");
            if (client.Name.Length > 40)
                throw new ValidationException("Name must be shorter than 40 symbols");
            if (string.IsNullOrWhiteSpace(client.Surname))
                throw new ValidationException("Surname cannot be empty");
            if (client.Surname.Length < 3)
                throw new ValidationException("Surname must be longer than 3 symbols");
            if (client.Surname.Length > 50)
                throw new ValidationException("Surname must be shorter than 50");
            if (client.DateOfBirth.Year < 1940)
                throw new ValidationException("Year of birth must be greater than 1940");
            if (client.DateOfBirth.Year > DateTime.Now.Year - 16)
                throw new ValidationException("Year of birth must be less than " + (DateTime.Now.Year - 16));
            if (string.IsNullOrWhiteSpace(client.Phone))
                throw new ValidationException("Phone cannot be empty");
            if (client.Phone.Length != 11)
                throw new ValidationException("Phone must has 11 symbols");
            if (string.IsNullOrWhiteSpace(client.IdentityNumber))
                throw new ValidationException("Identity number cannot be empty");
            if (client.IdentityNumber.Length != 11)
                throw new ValidationException("Identity number must has 11 symbols");
            if (client.CoachId != null && client.CoachId < 1)
                throw new ValidationException("Coach id must be greater than zero");
        }
    }
}
