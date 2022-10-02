using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemMarketplace.DAL.Interface
{
    public interface IBaseRepository <T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T sale);
        Task Update(T sale);
        Task Delete(int id);
    }
}
