using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Entities;

namespace SuperHeroApi.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<SuperHero> SuperHeroes { get; set; }
    }
}
