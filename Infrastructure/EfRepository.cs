using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sf.Budgeteer.ApplicationCore.Entities;
using Sf.Budgeteer.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sf.Budgeteer.Infrastructure
{
    public class EfRepository<T> : IAsyncRepository<T>, IRepository<T> where T : BaseEntity
    {
        private readonly BudgeteerContext _context;
        private readonly ILogger<EfRepository<T>> _logger;

        public EfRepository(BudgeteerContext context, ILogger<EfRepository<T>> logger)
        {
            _context = context;
            _logger = logger;
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public ValueTask<T> GetByIdAsync(int id)
        {
            return _context.Set<T>().FindAsync(id);
        }

        public T GetSingleBySpec(ISpecification<T> spec)
        {
            return List(spec).FirstOrDefault();
        }

        public IEnumerable<T> List(ISpecification<T> spec)
        {
            var queryableWithIncludes = spec.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                (current, include) => current.Include(include));

            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableWithIncludes,
                (current, include) => current.Include(include));

            return secondaryResult
                .Where(spec.Criteria)
                .AsEnumerable();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_context.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            // return the result of the query using the specification's criteria expression
            return await secondaryResult
                            .Where(spec.Criteria)
                            .ToListAsync();
        }
        public IEnumerable<T> ListAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> AddAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
