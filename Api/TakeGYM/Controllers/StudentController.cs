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
    public class StudentController : ControllerBase
    {

        private readonly IStudentFacade _studentFacade;

        /// <summary>
        ///  Construct Method
        /// </summary>
        public StudentController(IStudentFacade studentFacade)
        {
            _studentFacade = studentFacade;
        }

        /// <summary>
        /// List all students in database
        /// </summary>
        [HttpGet("list-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListAllStudentsAsync()
        {
            var result = await _studentFacade.ListAllAsync();
            if (result is null)
            {
                return NotFound("Not find teachers in database");
            }

            return Ok(result);
        }

        /// <summary>
        ///  Add students in database
        /// </summary>
        [HttpPost("insert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertStudentAsync([FromBody][Required] Student student)
        {
            var result = await _studentFacade.InsertAsync(student);
            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        ///  Remove students in database
        /// </summary>
        [HttpPost("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemovemStudentAsync([FromBody][Required] Student student)
        {
            var result = await _studentFacade.DeleteAsync(student);
            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        /// <summary>
        /// Verify if student has trainingsheet by phone
        /// </summary>
        [HttpGet("trainingsheet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> VerifyHasTrainsheetAsync(string phone)
        {

            return Ok(await _studentFacade.VerifyHasTrainingsheetAsync(phone));
        }

        /// <summary>
        /// Verify if student has personal by phone
        /// </summary>
        [HttpGet("personal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> VerifyHasPersonalAsync(string phone)
        {
            return Ok(await _studentFacade.VerifyHasPersonalAsync(phone));
        }


    }
}
