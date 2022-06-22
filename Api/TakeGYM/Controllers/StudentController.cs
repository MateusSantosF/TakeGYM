using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TakeGYM.Facades;
using TakeGYM.Facades.interfaces;
using TakeGYM.Models.Structures;
using TakeGYM.Models.Student;
using TakeGYM.Models.Teacher;

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
        private readonly ITrainingsheetFacade _trainingsheetFacade;

        /// <summary>
        ///  Construct Method
        /// </summary>
        public StudentController(IStudentFacade studentFacade, ITrainingsheetFacade trainingsheetFacade)
        {
            _studentFacade = studentFacade;
            _trainingsheetFacade = trainingsheetFacade;
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
        public async Task<IActionResult> RemovemStudentAsync(string studentId)
        {
            var result = await _studentFacade.DeleteAsync(studentId);
            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
        /// <summary>
        /// Verify if student has trainingsheet by phone
        /// </summary>
        [HttpGet("verify-trainingsheet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> VerifyHasTrainsheetAsync(string id)
        {
            return Ok(await _studentFacade.VerifyHasTrainingsheetAsync(id));
        }

        /// <summary>
        /// Verify if student has personal by phone
        /// </summary>
        [HttpGet("personal")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> VerifyHasPersonalAsync(string id)
        {
            return Ok(await _studentFacade.VerifyHasPersonalAsync(id));
        }

        /// <summary>
        /// Get trainingsheet student by phone
        /// </summary>
        [HttpGet("trainingsheet")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetTrainingsheetAsync(string id)
        {
            return Ok(await _trainingsheetFacade.GetTrainingSheet(id));
        }

    }
}
