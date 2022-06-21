using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using TakeGYM.Services.AppDbContext;
using TakeGYM.Services.Repository.interfaces;

namespace TakeGYM.Services.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly TakeGYMContext _context;
        public GenericRepository(TakeGYMContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(T model)
        {
            _context.Set<T>().Remove(model);
           await _context.SaveChangesAsync(); 
        }

        public async Task<List<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task InsertAsync(T model)
        {
            _context.Set<T>().Add(model);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T model)
        {
            _context.Update(model);
            await _context.SaveChangesAsync();
        }
    }
}
