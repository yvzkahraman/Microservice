using MarketModule.MarketService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketModule.MarketService.Data
{
    public class MarketDbContext : DbContext
    {
        public MarketDbContext(DbContextOptions<MarketDbContext> options) :base(options)
        {
            
        }
        public DbSet<Market> Markets { get; set; }
    }
}