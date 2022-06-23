using System.Collections.Generic;
using System.Threading.Tasks;

using TakeGYM.Models.Structures;
using TakeGYM.Models.Student;
using TakeGYM.Models.Teacher;

namespace TakeGYM.Facades
{
    public interface IStudentFacade
    {
        Task<Student> GetStudent(string phone);

        public Task<List<Student>> ListAllAsync();

        public Task<bool> InsertAsync(Student student);

        public Task<bool> DeleteAsync(string studentId);

        public Task<bool> UpdateAsync(Student student);

        public Task<bool> VerifyHasPersonalAsync(string phone);

        public Task<string> VerifyHasTrainingsheetAsync(string phone);

        public Task<bool> SignPersonalAsync(Teacher teacher, Schedule schedule, string phone);
        public Task<string> GetCepInfoAsync(string cep);
    }
}
