using System.Collections.Generic;
using System.Threading.Tasks;

using TakeGYM.Models.Teacher;

namespace TakeGYM.Facades
{
    public interface ITeacherFacade
    {
        public Task<List<Teacher>> ListAllAsync();

        public Task<List<Teacher>> ListAllPersonalAsync();

        public Task<bool> InsertAsync(Teacher teacher);     

        public Task<bool> DeleteAsync(string teacherId);

        public Task<bool> UpdateAsync(Teacher teacher);

        public Task<Teacher> FindByIdAsync(string teacherId);

    }
}
