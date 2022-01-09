using Microsoft.EntityFrameworkCore;

namespace DataBase 
{
    public class AppDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres1;Username=riko;Password=iablochko");
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=dnddndndnd;Integrated Security=True");
        }
        public DbSet<Monster> Monsters { get; set; }
    }
    
}