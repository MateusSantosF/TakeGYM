using System.Threading.Tasks;

using Newtonsoft.Json;

using TakeGYM.Facades.interfaces;
using TakeGYM.Models.TrainingSheet;
using TakeGYM.Services.Repository.interfaces;

namespace TakeGYM.Facades
{
    public class TrainingsheetFacade: ITrainingsheetFacade
    {

        private readonly IGenericRepository<TrainingSheet> _traininsheetRepository;
        private readonly IStudentFacade _studentFacade;

        public TrainingsheetFacade(IGenericRepository<TrainingSheet> trainingsheetRepository, IStudentFacade studentFacade)
        {
            _traininsheetRepository = trainingsheetRepository;
            _studentFacade = studentFacade;
        }

        public async Task<string> GetTrainingSheetByphoneAsync(string phone)
        {
            var student = await _studentFacade.GetStudentByPhoneAsync(phone);
            var result =  await _traininsheetRepository.FindBy(t => t.StudentID.Equals(student.StudentID));

            return JsonConvert.SerializeObject(result, Formatting.Indented);
        }

    }
}
