using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using TakeGYM.Facades;
using TakeGYM.Models.Teacher;

namespace TakeGYM.Controllers
{
    /// <summary>
    /// Teacher Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        private readonly ITeacherFacade _teacherFacade;

        /// <summary>
        ///  Construct Method
        /// </summary>
        public TeacherController(ITeacherFacade teacherFacade)
        {
            _teacherFacade = teacherFacade;
        }

        /// <summary>
        /// List all teacher in database
        /// </summary>
        [HttpGet("list-all")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> ListAllTeachersAsync()
        {
            var result = await _teacherFacade.ListAllAsync();
            if (result is null)
            {
                return NotFound("Not find teachers in database");
            }

            return Ok(result);
        }

        /// <summary>
        ///  Get Teacher by Id
        /// </summary>
        [HttpGet("teacher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> FindTeacherByIdAsync(string teacherId)
        {
            var result = await _teacherFacade.FindByIdAsync(teacherId);
            if (result is null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        ///  Add Teacher in database
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        [HttpPost("insert")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> InsertTeacherAsync([FromBody][Required] Teacher teacher)
        {
            var result = await _teacherFacade.InsertAsync(teacher);
            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        /// <summary>
        ///  Remove Teacher in database
        /// </summary>
        [HttpPost("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveTeacherAsync(string teacherId)
        {
            var result = await _teacherFacade.DeleteAsync(teacherId);
            if (!result)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    


    }
}
