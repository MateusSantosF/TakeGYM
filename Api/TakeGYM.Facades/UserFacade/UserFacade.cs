using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using TakeGYM.Models.Student;
using TakeGYM.Models.Teacher;
using TakeGYM.Services.Repository.interfaces;

namespace TakeGYM.Facades
{
    public class UserFacade : IUserFacade
    {

        private readonly IGenericRepository<Student> _studentRepository;
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public UserFacade(IGenericRepository<Student> studentRepository, IGenericRepository<Teacher> teacherRepository)
        {
            _studentRepository = studentRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<string> VerifyRegisterAsync(string cpf)
        {

            var students = await _studentRepository.FindBy(student => student.CPF.Equals(cpf));

            if (students.Any())
            {

                JObject student = JObject.FromObject(students.First());
                student.Add("IsTeacher", "false");
        
                return JsonConvert.SerializeObject(student, Formatting.Indented);
            }


            var teachers = await _teacherRepository.FindBy(teacher => teacher.CPF.Equals(cpf));

            if (teachers.Any())
            {       
                JObject teacher = JObject.FromObject(teachers.First());
                teacher.Add("IsTeacher","true");
                return JsonConvert.SerializeObject(teacher, Formatting.Indented);
            }

            return string.Empty;
        }
    }
}
