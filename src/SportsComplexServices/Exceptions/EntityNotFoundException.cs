namespace SportsComplex.Services.Exceptions
{
    public class EntityNotFoundException : ServicesException
    {
        internal EntityNotFoundException(string message) : base(message) { }
    }
}
