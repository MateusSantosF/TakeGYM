
using System.Collections.Generic;
using System.Threading.Tasks;

using TakeGYM.Models.Exercise;
using TakeGYM.Services.Repository.interfaces;

namespace TakeGYM.Facades.PersonalFacades
{
    public class PersonalFacade : IPersonalFacade
    {
        private readonly IGenericRepository<Exercise> _exerciseRepository;

        public PersonalFacade(IGenericRepository<Exercise> exerciseRepository)
        {
            _exerciseRepository = exerciseRepository;
        }
        public async Task<List<Exercise>> TestEndpointAsync()
        {
            return await _exerciseRepository.ListAllAsync();
        }


    }
}
