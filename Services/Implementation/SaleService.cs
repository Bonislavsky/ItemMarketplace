using ItemMarketplace.DAL.Interface;
using ItemMarketplace.Models;
using ItemMarketplace.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMarketplace.Services.Implementation
{
    public class SaleService : IBaseService
    {
        public Task<List<Sale>> GetSales()
        {
            throw new NotImplementedException();
        }
    }
}
