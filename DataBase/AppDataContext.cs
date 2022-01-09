using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataBase 
{
    public class AppDataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=dndtask;Integrated Security=True");
        }

        public DbSet<Monster> Monsters { get; set; }
    }
    
}