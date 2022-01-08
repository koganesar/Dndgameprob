using Microsoft.EntityFrameworkCore;

namespace DataBase 
{
    public class AppDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres1;Username=riko;Password=iablochko");
        }
        public DbSet<Monster> Monsters { get; set; }
    }
    
}