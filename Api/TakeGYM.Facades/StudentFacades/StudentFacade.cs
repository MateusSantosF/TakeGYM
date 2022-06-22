using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using TakeGYM.Models.Student;
using TakeGYM.Models.TrainingSheet;
using TakeGYM.Services.Repository.interfaces;
using Newtonsoft.Json;

namespace TakeGYM.Facades
{
    public class StudentFacade :IStudentFacade{

        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<TrainingSheet> _trainingsheetRepository;

        public StudentFacade(IGenericRepository<Student> studentRepository, IGenericRepository<TrainingSheet> trainingsheetRepository)
        {
            _studentRepository = studentRepository;
            _trainingsheetRepository = trainingsheetRepository;
        }

        public async Task<bool> DeleteAsync(Student student)
        {
            return await _studentRepository.DeleteAsync(student);
        }


        public async Task<bool> InsertAsync(Student student)
        {
            return await _studentRepository.InsertAsync(student);
        }

        public async Task<Student> GetStudentByPhoneAsync(string phone)
        {
            return await _studentRepository.Find(s => s.Phone.Equals(phone));
        }

        public async Task<List<Student>> ListAllAsync()
        {
            return await _studentRepository.ListAllAsync();
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }

        public async Task<bool> VerifyHasPersonalAsync(string phone)
        {
            var student = await _studentRepository.Find(s => s.Phone.Equals(phone));

            if(student is null)
            {
                return false;
            }

            return student.HasPersonal;
        }

        public async Task<string> VerifyHasTrainingsheetAsync(string phone)
        {
            var student = await _studentRepository.Find(s => s.Phone.Equals(phone));
            var trainingSheet = await _trainingsheetRepository.Find(t => t.StudentID.Equals(student.StudentID));

            return JsonConvert.SerializeObject(trainingSheet, Formatting.Indented);
        }
    }
}
