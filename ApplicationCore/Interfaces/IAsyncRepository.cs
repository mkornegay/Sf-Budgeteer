using System.Collections.Generic;
using System.Threading.Tasks;
using Sf.Budgeteer.ApplicationCore.Entities;

namespace Sf.Budgeteer.ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T: BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
        Task<List<T>> ListAsync(ISpecification<T> spec);
        Task<T> Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
