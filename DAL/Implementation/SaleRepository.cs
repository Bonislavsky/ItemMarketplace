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
    public class SaleRepository : ISaleRepository
    {
        private readonly MarketplaceDbContext _Dbase;

        public SaleRepository(MarketplaceDbContext ctx )
        {
            _Dbase = ctx;
        }

        public async Task<List<Sale>> GetAll()
        {
            return await _Dbase.Sales.ToListAsync();
        }

        public async Task<Sale> Create(Sale sale)
        {
            await _Dbase.Sales.AddAsync(sale);
            await _Dbase.SaveChangesAsync();
            return sale;
        }

        public async Task<Sale> GetById(int id)
        {
            return await _Dbase.Sales.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async void Update(Sale sale)
        {
            _Dbase.Attach(sale).State = EntityState.Modified;
            await _Dbase.SaveChangesAsync();
        }

        public async void Delete(int id)
        {
            var model = await _Dbase.Sales.FirstOrDefaultAsync(e => e.Id == id);
            _Dbase.Sales.Remove(model);
            await _Dbase.SaveChangesAsync();
        }
    }
}
