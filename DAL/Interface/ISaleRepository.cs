using ItemMarketplace.Domain.Enum;
using ItemMarketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMarketplace.DAL.Interface
{
    public interface ISaleRepository : IBaseRepository<Sale>
    {
        Task<List<Sale>> GetSortedSalesByItemName(string itemName, MarketStatus status, SortingBy sort_key, OrderBy sort_order);
    }
}
