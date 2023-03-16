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
    public class TopicsController : ControllerBase
    {
        private readonly ITopicsRepository topicsRepository;

        public TopicsController(ITopicsRepository _topicsRepository)
        {
            topicsRepository = _topicsRepository;
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(TopicsDTO topicsDTO)
        {
            try
            {
                int Id = await topicsRepository.Insert(topicsDTO);
                if (Id != 0)
                {
                    return Ok("Succsess");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = "Faild to add Topics" });
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
                return StatusCode(StatusCodes.Status200OK, await topicsRepository.LoadAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
       /* [HttpGet]
        [Route("LoadByCourseId")]
        public Topics LoadByCourseId(int Id)
        {
            return topicsRepository.LoadByCourseId(Id);
        }*/
        [HttpGet]
        [Route("Load")]
        public async Task<IActionResult> Load(int Id)
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, await topicsRepository.Load(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }

        }

        [HttpGet]
        [Route("MainTopics")]
        public List<Topics> MainCategories()
        {
            return topicsRepository.MainTopics();
        }

        [HttpGet]
        [Route("SubTopics")]
        public List<Topics> SubTopics()
        {
            return topicsRepository.SubTopics();
        }

        [HttpGet]
        [Route("LoadTopicsByCourseID")]
        public List<Topics> LoadTopicsByCourseID(int Id)
        {
            return topicsRepository.LoadTopicsByCourseID(Id);
        }

        [HttpGet]
        [Route("MainTopics1")]
        public List<Topics> MainTopics1(int Id)
        {
            return topicsRepository.MainTopics1(Id);
        }


        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(TopicsDTO topicsDTO)
        {
            try
            {
                await topicsRepository.Update(topicsDTO);
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
                await topicsRepository.Delete(Id);
                return Ok("Succsess");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
    }
}