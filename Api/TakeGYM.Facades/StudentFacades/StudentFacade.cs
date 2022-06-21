using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using TakeGYM.Models.Student;
using TakeGYM.Services.Repository.interfaces;

namespace TakeGYM.Facades
{
    public class StudentFacade :IStudentFacade{

        private readonly IGenericRepository<Student> _studentRepository;

        public StudentFacade(IGenericRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<bool> DeleteAsync(Student student)
        {
            return await _studentRepository.DeleteAsync(student);
        }

        public async Task<bool> InsertAsync(Student student)
        {
            return await _studentRepository.InsertAsync(student);
        }

        public async Task<List<Student>> ListAllAsync()
        {
            return await _studentRepository.ListAllAsync();
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }

        public Task<string> VerifyHasPersonalAsync(string phone)
        {
            throw new NotImplementedException();
        }

        public Task<string> VerifyHasTrainingsheetAsync(string phone)
        {
            throw new NotImplementedException();
        }
    }
}
