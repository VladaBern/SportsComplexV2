namespace SportsComplex.Repository.Interfaces.Models
{
    public class Coach
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string IdentityNumber { get; set; }
        public int DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}
