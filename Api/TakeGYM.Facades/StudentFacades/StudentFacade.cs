using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


using TakeGYM.Models.Student;
using TakeGYM.Models.TrainingSheet;
using TakeGYM.Services.Repository.interfaces;
using Newtonsoft.Json;
using TakeGYM.Models.Structures;
using TakeGYM.Models.Teacher;
using System.Net.Http;
using TakeGYM.Models;

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

        public async Task<bool> DeleteAsync(string studentId)
        {
            return await _studentRepository.DeleteAsync(studentId);
        }


        public async Task<bool> InsertAsync(Student student)
        {
            student.Id = Guid.NewGuid().ToString();

            return await _studentRepository.InsertAsync(student);
        }

        public async Task<Student> GetStudent(string id)
        {
            return await _studentRepository.Find(s => s.Id.Equals(id));
        }

        public async Task<List<Student>> ListAllAsync()
        {
            return await _studentRepository.ListAllAsync();
        }

        public async Task<bool> UpdateAsync(Student student)
        {
            return await _studentRepository.UpdateAsync(student);
        }

        public async Task<bool> VerifyHasPersonalAsync(string id)
        {
            var student = await _studentRepository.Find(s => s.Id.Equals(id));

            if(student is null)
            {
                return false;
            }

            return student.HasPersonal;
        }

        public async Task<string> VerifyHasTrainingsheetAsync(string id)
        {
            var student = await _studentRepository.Find(s => s.Id.Equals(id));
            var trainingSheet = await _trainingsheetRepository.Find(t => t.StudentID.Equals(student.Id));

            return JsonConvert.SerializeObject(trainingSheet, Formatting.Indented);
        }

        public async Task<bool> SignPersonalAsync(Teacher teacher, Schedule schedule, string phone)
        {
            var student = await _studentRepository.Find(s => s.Phone.Equals(phone));

            if(student is null)
            {
                return false;
            }

            student.Teacher = teacher;
            student.HasPersonal = true;
            student.PersonalSchedule = schedule;

            return await _studentRepository.UpdateAsync(student);
        }

        public async Task<string> GetCepInfoAsync(string cep)
        {

            HttpClient client = new HttpClient();

            var response = await client.GetAsync($"{Constants.HTTPS}viacep.com.br/ws/{cep}/json/");
            string responseBody = await response.Content.ReadAsStringAsync();

            return responseBody;
        }
    }
}
