using Bbk.Data.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bbk.Data.Repository
{
    public interface IRepositoryBase<T, Tkey> 
        where T : class
    {
        IEnumerable<T> GetAll();

        Task<T> GetByIdAsync(Tkey id);

        Task<T> FindAsync(
            [NotNull] Expression<Func<T, bool>> predicate,
            bool includeDetails = true
        );

        
        Task<T> GetAsync(
            [NotNull] Expression<Func<T, bool>> predicate,
            bool includeDetails = true
        );

        
        Task DeleteAsync(
            [NotNull] Expression<Func<T, bool>> predicate,
            bool autoSave = false
        );

    }

    public abstract class RepositoryBase<T, Tkey> : IRepositoryBase<T, Tkey> where T : class
    {
        protected BBKDbContext _context = null;

        internal DbSet<T> table = null;

        public RepositoryBase(
                 BBKDbContext context
            )
        {
            this._context = context; 

            this.table = _context.Set<T>(); 
        }

        public Task DeleteAsync([NotNull] Expression<Func<T, bool>> predicate, bool autoSave = false)
        {
            throw new NotImplementedException();
        }

        public async Task<T> FindAsync([NotNull] Expression<Func<T, bool>> predicate, bool includeDetails = true)
        {
            return await this.table.Where(predicate).FirstOrDefaultAsync(); 
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync([NotNull] Expression<Func<T, bool>> predicate, bool includeDetails = true)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync (Tkey id)
        {
           return await  table.FindAsync(id); 
        }  
    }
}
