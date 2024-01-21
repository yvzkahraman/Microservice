using System.Linq.Expressions;
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

        public async Task<List<Market>> GetAll()
        {
            return await this.context.Markets.AsNoTracking().ToListAsync();
        }

        public async Task<Market> Create(Market market)
        {
            await this.context.Markets.AddAsync(market);
            await this.context.SaveChangesAsync();
            return market;
        }

        public async Task Remove(Market market)
        {
            this.context.Remove(market);
            await this.context.SaveChangesAsync();
        }

        public async Task<Market?> FindByFilter(Expression<Func<Market, bool>> filter)
        {
            return await this.context.Markets.SingleOrDefaultAsync(filter);
        }

        public async Task<Market?> GetByFilter(Expression<Func<Market,bool>> filter){
             return await this.context.Markets.AsNoTracking().SingleOrDefaultAsync(filter);
        }

        public async Task Update(){
            await this.context.SaveChangesAsync();
        }
    }
}