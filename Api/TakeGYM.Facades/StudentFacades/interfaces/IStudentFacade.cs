using System.Collections.Generic;
using System.Threading.Tasks;

using TakeGYM.Models.Student;

namespace TakeGYM.Facades
{
    public interface IStudentFacade
    {
        public Task<List<Student>> ListAllAsync();

        public Task<bool> InsertAsync(Student student);

        public Task<bool> DeleteAsync(Student student);

        public Task<bool> UpdateAsync(Student student);

        public Task<bool> VerifyHasPersonalAsync(string phone);

        public Task<string> VerifyHasTrainingsheetAsync(string phone);

    }
}
