using SportsComplex.Services.Exceptions;

namespace SportsComplex.Services.Validators.Exceptions
{
    public class ValidationException : ServicesException
    {
        internal ValidationException(string message) : base(message) { }
    }
}
