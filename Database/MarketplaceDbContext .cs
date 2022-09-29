using ItemMarketplace.Models;
using Microsoft.EntityFrameworkCore;

namespace ItemMarketplace.Database
{
    public class MarketplaceDbContext : DbContext
    {
        public MarketplaceDbContext(DbContextOptions<MarketplaceDbContext> options): base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Sale> Sales { get; set; }
    }
}
