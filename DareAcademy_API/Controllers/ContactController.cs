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
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository contactRepository;

        public ContactController(IContactRepository _contactRepository)
        {
            contactRepository = _contactRepository;
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(ContactDTO contactDTO)
        {
            try
            {
                int Id = await contactRepository.Insert(contactDTO);
                if (Id != 0)
                {
                    return Ok("Succsess");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = "Faild to add Contact" });
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
                return StatusCode(StatusCodes.Status200OK, await contactRepository.LoadAll());
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
                return StatusCode(StatusCodes.Status200OK, await contactRepository.Load(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }

        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(ContactDTO contactDTO)
        {
            try
            {
                await contactRepository.Update(contactDTO);
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
                await contactRepository.Delete(Id);
                return Ok("Succsess");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
    }
}
