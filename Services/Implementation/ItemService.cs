using ItemMarketplace.DAL.Interface;
using ItemMarketplace.Models;
using ItemMarketplace.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMarketplace.Services.Implementation
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Item>> GetListEntity()
        {
            return await _itemRepository.GetAll();
        }


        public async Task<Item> GetEntityById(int id)
        {
            return await _itemRepository.GetById(id);
        }

        public void UpdateEntity(Item sale)
        {
            _itemRepository.Update(sale);
        }

        public async Task<Item> CreateEntity(Item sale)
        {
            return await _itemRepository.Create(sale);
        }

        public void DeleteEntityById(int id)
        {
            _itemRepository.Delete(id);
        }

    }
}
