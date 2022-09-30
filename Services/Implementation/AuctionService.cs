using ItemMarketplace.DAL.Interface;
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
        private readonly IItemRepository _itemRepository;

        public AuctionService(ISaleRepository saleRepository, IItemRepository itemRepository)
        {
            _saleRepository = saleRepository;
            _itemRepository = itemRepository;
        }

        public async Task<List<Sale>> GetSales()
        {
            return await _saleRepository.GetAll();
        }


        public async Task<Sale> GetSale(int id)
        {
            return await _saleRepository.GetById(id);
        }

        public void UpdateSale(Sale sale)
        {
            _saleRepository.Update(sale);
        }

        public async Task<Sale> CreateSale(Sale sale)
        {
            return await _saleRepository.Create(sale);
        }

        public void DeleteSale(int id)
        {
            _saleRepository.Delete(id);
        }
    }
}
