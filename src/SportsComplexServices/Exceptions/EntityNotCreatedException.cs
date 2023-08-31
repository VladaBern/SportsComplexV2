namespace SportsComplex.Services.Exceptions
{
    public class EntityNotCreatedException : ServicesException
    {
        internal EntityNotCreatedException(string message) : base(message) { }
    }
}
