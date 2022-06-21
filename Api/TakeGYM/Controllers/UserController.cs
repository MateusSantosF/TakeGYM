using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TakeGYM.Facades;
using TakeGYM.Models.Student;


namespace TakeGYM.Controllers
{
    /// <summary>
    /// Student Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserFacade _userFacade;

        /// <summary>
        ///  Construct Method
        /// </summary>
        public UserController(IUserFacade userFacade)
        {
            _userFacade = userFacade;
        }

        /// <summary>
        ///  Verify if user contains register in database by phone number
        /// </summary>
        /// <returns></returns>
        [HttpGet("verify-registry")]
        public async Task<IActionResult> VerifyRegistryByPhoneAsync(string phone)
        {
            var result = await _userFacade.VerifyRegisterByPhoneAsync(phone);
            return Ok(result);
        }



    }
}
