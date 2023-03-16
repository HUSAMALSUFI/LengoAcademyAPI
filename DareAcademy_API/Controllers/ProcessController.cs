using DareAcademy_API.Models;
using DareAcademy_BusinessLogic.SpecificReposoitory;
using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DareAcademy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessRepository processRepository;

        public ProcessController(IProcessRepository _processRepository)
        {
            processRepository = _processRepository;
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ProcessDTO processDTO)
        {
            try
            {
                int Id = await processRepository.Insert(processDTO);
                if (Id != 0)
                {
                    return Ok("Succsess");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = "Faild to add Process" });
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
                return StatusCode(StatusCodes.Status200OK, await processRepository.LoadAll());
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
                return StatusCode(StatusCodes.Status200OK, await processRepository.Load(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }

        }
        /* [HttpGet]
         [Route("Load")]
         public Process Load(int Id)
         {
             return processRepository.Load(Id);
         }*/

        [HttpGet]
        [Route("LoadProcessByCourseID")]
        public List<Process> LoadProcessByCourseID( int Id)
        {
            return processRepository.LoadProcessByCourseID(Id);
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(ProcessDTO processDTO)
        {
            try
            {
                await processRepository.Update(processDTO);
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
                await processRepository.Delete(Id);
                return Ok("Succsess");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
    }
}
