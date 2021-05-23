using System.Collections.Generic;
using System.Threading.Tasks;
using Sf.Budgeteer.ApplicationCore.Entities;

namespace Sf.Budgeteer.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T: BaseEntity
    {
        ValueTask<T> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
