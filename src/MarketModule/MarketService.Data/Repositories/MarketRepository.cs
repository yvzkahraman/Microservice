using MarketModule.MarketService.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketModule.MarketService.Data.Repositories
{
    public class MarketRepository
    {
        private readonly MarketDbContext context;

        public MarketRepository(MarketDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Market>> GetMarket()
        {
            return await this.context.Markets.AsNoTracking().ToListAsync();
        }
    }
}