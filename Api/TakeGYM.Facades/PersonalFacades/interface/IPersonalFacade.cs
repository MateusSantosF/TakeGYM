using System.Collections.Generic;
using System.Threading.Tasks;

using TakeGYM.Models.Exercise;

namespace TakeGYM.Facades.PersonalFacades
{
    public interface IPersonalFacade
    {
        public Task<List<Exercise>> TestEndpointAsync();
    }
}
