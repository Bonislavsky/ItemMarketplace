using ItemMarketplace.DAL.Interface;
using ItemMarketplace.Domain.Enum;
using ItemMarketplace.Models;
using ItemMarketplace.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMarketplace.Services.Implementation
{
    public class AuctionService : IAuctionService
    {
        private readonly ISaleRepository _saleRepository;

        public AuctionService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<Sale>> GetListEntity()
        {
            return await _saleRepository.GetAll();
        }


        public async Task<Sale> GetEntityById(int id)
        {
            return await _saleRepository.GetById(id);
        }

        public void UpdateEntity(Sale sale)
        {
            _saleRepository.Update(sale);
        }

        public async Task<Sale> CreateEntity(Sale sale)
        {
            sale.CreatedDt = DateTime.Now;
            return await _saleRepository.Create(sale);
        }

        public void DeleteEntityById(int id)
        {
            _saleRepository.Delete(id);
        }

        public async Task<List<Sale>> GetSortingSales(string name, MarketStatus status, SortingBy sort_key, OrderBy sort_order)
        {
            return await _saleRepository.GetSortedSalesByItemName(name, status, sort_key, sort_order);
        }
    }
}
    