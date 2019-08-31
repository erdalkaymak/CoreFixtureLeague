using Microsoft.EntityFrameworkCore;
namespace DAL.Model
{
    public class FixtureDemoContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Fixture> Fixtures { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\;Database=LeagueDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        
    }
}
