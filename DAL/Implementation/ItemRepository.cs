using ItemMarketplace.DAL.Interface;
using ItemMarketplace.Database;
using ItemMarketplace.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMarketplace.DAL.Implementation
{
    public class ItemRepository : IItemRepository
    {
        private readonly MarketplaceDbContext _Dbase;

        public ItemRepository(MarketplaceDbContext ctx)
        {
            _Dbase = ctx;
        }

        public async Task<List<Item>> GetAll()
        {
            return await _Dbase.Items.ToListAsync();
        }

        public async Task<Item> Create(Item item)
        {
            await _Dbase.Items.AddAsync(item);
            await _Dbase.SaveChangesAsync();
            return item;
        }

        public async Task<Item> GetById(int id)
        {
            return await _Dbase.Items.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task Update(Item item)
        {
            _Dbase.Attach(item).State = EntityState.Modified;
            await _Dbase.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var model = await _Dbase.Items.FirstOrDefaultAsync(e => e.Id == id);
            _Dbase.Items.Remove(model);
            await _Dbase.SaveChangesAsync();
        }
    }
}
