using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Contracts.Persistance.CommonRepository
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Guid Id);
        Task<IReadOnlyList<T>> GetAll();
        Task<bool> Exist(Guid id);
        Task<T> Add(T Entity);
        Task Update(T Entity);
        Task Delete(T Entity);
    }
}
