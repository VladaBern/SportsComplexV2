using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Validators
{
    public interface IClientValidator
    {
        Task ValidateAsync(ClientDto client);
    }
}
