using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseEntity 
    {
        private readonly StoreContext _context;
        public GenericRepository(StoreContext context) 
        {
            _context = context;
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        async Task<IReadOnlyList<T>> IGenericRepository<T>.GetAllWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).ToListAsync();
        }
        async Task<T> IGenericRepository<T>.GetWithSpecification(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).FirstOrDefaultAsync();
        }
        async Task<int> IGenericRepository<T>.CountAsync(ISpecification<T> specification)
        {
            return await ApplySpecification(specification).CountAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> specification) 
        {
            return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(),specification);
        }
    }
}
