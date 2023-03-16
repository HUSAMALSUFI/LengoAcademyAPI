using DareAcademy_API.Models;
using DareAcademy_BusinessLogic.SpecificReposoitory;
using DareAcademy_DataAccess.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DareAcademy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Course_ScheduleController : ControllerBase
    {
        private readonly ICourse_ScheduleRepository course_ScheduleRepository;

        public Course_ScheduleController(ICourse_ScheduleRepository _course_ScheduleRepository)
        {
            course_ScheduleRepository = _course_ScheduleRepository;
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(Course_ScheduleDTO course_ScheduleDTO)
        {
            try
            {
                int Id = await course_ScheduleRepository.Insert(course_ScheduleDTO);
                if (Id != 0)
                {
                    return Ok("Succsess");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = "Faild to add course Schedule" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("LoadAll")]
        public async Task<IActionResult> LoadAll()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await course_ScheduleRepository.LoadAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("Load")]
        public async Task<IActionResult> Load(int Id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await course_ScheduleRepository.Load(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }

        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(Course_ScheduleDTO course_ScheduleDTO)
        {
            try
            {
                await course_ScheduleRepository.Update(course_ScheduleDTO);
                return Ok("Succsess");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
        [HttpGet]
        [Route("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await course_ScheduleRepository.Delete(Id);
                return Ok("Succsess");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
    }
}
