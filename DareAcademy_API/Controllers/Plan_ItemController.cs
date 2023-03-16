using DareAcademy_API.Models;
using DareAcademy_BusinessLogic.SpecificReposoitory;
using DareAcademy_DataAccess.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DareAcademy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Plan_ItemController : ControllerBase
    {
        private readonly IPlan_ItemRepositorycs planItemRepository;

        public Plan_ItemController(IPlan_ItemRepositorycs _planItemRepository)
        {
            planItemRepository = _planItemRepository;
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(Plan_ItemDTO plan_ItemDTO)
        {
            try
            {
                await planItemRepository.Insert(plan_ItemDTO);
                return Ok("Succsess");
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
                return StatusCode(StatusCodes.Status200OK, await planItemRepository.LoadAll());
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
                await planItemRepository.Delete(Id);
                return Ok("Succsess");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(Plan_ItemDTO plan_ItemDTO)
        {
            try
            {
                await planItemRepository.Update(plan_ItemDTO);
                return Ok("Succsess");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
    }
}