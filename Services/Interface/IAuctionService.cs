using ItemMarketplace.Domain.Enum;
using ItemMarketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMarketplace.Services.Interface
{
    public interface IAuctionService : IBaseService<Sale>
    {
        Task<List<Sale>> GetSortingSales(string name, MarketStatus status, SortingBy sort_key, OrderBy sort_order);
    }
}
