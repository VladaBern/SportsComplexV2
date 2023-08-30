using Microsoft.EntityFrameworkCore;
using SportsComplex.Repository.Interfaces.Models;

namespace SportsComplex.Repository
{
    public class SportsComplexDbContext : DbContext
    {
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Client> Clients { get; set; }

        public SportsComplexDbContext(DbContextOptions<SportsComplexDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Discipline>()
                .HasKey(d => d.Id);
            modelBuilder.Entity<Discipline>()
                .Property(d => d.Name)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Discipline>()
                .HasMany(d => d.Coaches)
                .WithOne(c => c.Discipline)
                .HasForeignKey(c => c.DisciplineId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Coach>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<Coach>()
                .Property(c => c.Name)
                .HasMaxLength(40)
                .IsRequired();
            modelBuilder.Entity<Coach>()
                .Property(c => c.Surname)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Coach>()
                .Property(c => c.DateOfBirth)
                .HasColumnType("date")
                .IsRequired();
            modelBuilder.Entity<Coach>()
                .Property(c => c.Phone)
                .HasMaxLength(11)
                .IsRequired();
            modelBuilder.Entity<Coach>()
                .Property(c => c.IdentityNumber)
                .HasMaxLength(11)
                .IsRequired();
            modelBuilder.Entity<Coach>()
                .HasMany(c => c.Clients)
                .WithOne(cl => cl.Coach)
                .HasForeignKey(cl => cl.CoachId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Client>()
                .HasKey(cl => cl.Id);
            modelBuilder.Entity<Client>()
                .Property(cl => cl.Name)
                .HasMaxLength(40)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(cl => cl.Surname)
                .HasMaxLength(50)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(cl => cl.DateOfBirth)
                .HasColumnType("date")
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(cl => cl.Phone)
                .HasMaxLength(11)
                .IsRequired();
            modelBuilder.Entity<Client>()
                .Property(cl => cl.IdentityNumber)
                .HasMaxLength(11)
                .IsRequired();
        }
    }
}
