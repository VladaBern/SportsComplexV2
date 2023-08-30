namespace SportsComplex.Services.Interfaces.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string IdentityNumber { get; set; }
        public int? CoachId { get; set; }
    }
}
