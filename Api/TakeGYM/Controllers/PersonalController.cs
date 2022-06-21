using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TakeGYM.Facades.PersonalFacades;

namespace TakeGYM.Controllers
{
    /// <summary>
    /// Personal Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalController : ControllerBase
    {

        private readonly IPersonalFacade _personalFacade;

        /// <summary>
        ///  Construct Method
        /// </summary>
        public PersonalController(IPersonalFacade personalFacade)
        {
            _personalFacade = personalFacade;
        }

        /// <summary>
        /// Test endpoint
        /// </summary>
        [HttpGet("test")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> TestAsync()
        {
            var result = await _personalFacade.TestEndpointAsync();
            if (result is null)
            {
                return NotFound("Not find exercises");
            }

            return Ok(result);
        }


    }
}
