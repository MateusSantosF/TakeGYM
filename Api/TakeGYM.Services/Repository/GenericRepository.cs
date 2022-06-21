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



        public async Task<List<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

     

        public async Task<List<T>> ListAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> InsertAsync(T model)
        {
            _context.Set<T>().Add(model);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> DeleteAsync(T model)
        {
            _context.Set<T>().Remove(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(T model)
        {
            _context.Update(model);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<T> Find(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(predicate);
        }
    }
}
