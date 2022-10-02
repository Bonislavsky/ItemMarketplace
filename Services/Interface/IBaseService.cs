using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMarketplace.Services.Interface
{
    public interface IBaseService<T>
    {
        Task<List<T>> GetListEntity();
        Task<T> GetEntityById(int id);
        Task<T> CreateEntity(T sale);
        void UpdateEntity(T sale);
        void DeleteEntityById(int id);
    }
}
