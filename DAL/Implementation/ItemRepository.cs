using ItemMarketplace.DAL.Interface;
using ItemMarketplace.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMarketplace.DAL.Implementation
{
    public class ItemRepository : IItemRepository
    {
        public Task<Item> Create(Item sale)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Item>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Item> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Item sale)
        {
            throw new NotImplementedException();
        }
    }
}
