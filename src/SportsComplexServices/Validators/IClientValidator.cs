using SportsComplex.Services.Interfaces.DTO;

namespace SportsComplex.Services.Validators
{
    public interface IClientValidator
    {
        void Validate(ClientDto client);
    }
}
