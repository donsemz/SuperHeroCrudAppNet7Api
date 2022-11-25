using Microsoft.EntityFrameworkCore;

namespace SuperHeroCrudAppNet7Api.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
                
        }
        // use this if u dont want to set things in the app.config
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=NewHeroes;Integrated Security=true;Encrypt=False;TrustServerCertificate=true");
        }*/

        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
