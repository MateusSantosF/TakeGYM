using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TakeGYM.Services.Repository.interfaces
{
    public interface IGenericRepository<T> where T : class
    {

        Task<List<T>> ListAllAsync();

        Task<List<T>> FindBy(Expression<Func<T, bool>> predicate);


        Task<bool> InsertAsync(T model);

        Task<bool> UpdateAsync(T model);

        Task<bool> DeleteAsync(T model);
    }
}
