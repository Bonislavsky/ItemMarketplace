using ItemMarketplace.DAL.Interface;
using ItemMarketplace.Database;
using ItemMarketplace.Domain.Enum;
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

        public async Task Update(Sale sale)
        {
            _Dbase.Attach(sale).State = EntityState.Modified;
            await _Dbase.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var model = await _Dbase.Sales.FirstOrDefaultAsync(e => e.Id == id);
            _Dbase.Sales.Remove(model);
            await _Dbase.SaveChangesAsync();
        }   

        public async Task<List<Sale>> GetSortedSalesByItemName(string itemName, MarketStatus status, SortingBy sort_key, OrderBy sort_order)
        {
            var ListSoles = await _Dbase.Sales
                .Where(b => 
                    _Dbase.Items.Any(a => a.Id == b.ItemId && a.Name.ToLower().Equals(itemName) && b.Status == status))
                .ToListAsync();

            switch (sort_key)
            {
                case SortingBy.CreatedDt:
                    if (sort_order == OrderBy.ACS)
                    {
                        ListSoles.Sort((x, y) => x.CreatedDt.CompareTo(y.CreatedDt));
                    }
                    else if (sort_order == OrderBy.DESC)
                    {
                        ListSoles.Sort((x, y) => y.CreatedDt.CompareTo(x.CreatedDt));
                    }
                    break;

                case SortingBy.Price:
                    if (sort_order == OrderBy.ACS)
                    {
                        ListSoles.Sort((x, y) => x.Price.CompareTo(y.Price));
                    }
                    else if (sort_order == OrderBy.DESC)
                    {
                        ListSoles.Sort((x, y) => y.Price.CompareTo(x.Price));
                    }
                    break;
            }
            return ListSoles;
        }
    }
}
