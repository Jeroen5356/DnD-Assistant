using Microsoft.EntityFrameworkCore;
using DataLayer.Entities.Entites;

namespace DataLayer.Entites
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConflictTeam>()
                .HasKey(ct => new { ct.ConflictId, ct.TeamId });
            modelBuilder.Entity<PersonTeam>()
                .HasKey(pt => new { pt.PersonId, pt.TeamId });
        }

        public DbSet<Conflict> Conflict { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<ConflictTeam> ConflictTeam { get; set; }
        public DbSet<PersonTeam> PersonTeam { get; set; }

    }
}
