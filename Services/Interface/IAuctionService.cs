using ItemMarketplace.Domain.Enum;
using ItemMarketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMarketplace.Services.Interface
{
    public interface IAuctionService
    {
        Task<List<Sale>> GetSales();
        Task<List<Sale>> GetSortingSales(string name, MarketStatus status, SortingBy sort_key, OrderBy sort_order);
        Task<Sale> GetSale(int id);
        Task<Sale> CreateSale(Sale sale);
        void UpdateSale(Sale sale);
        void DeleteSale(int id);
    }
}
