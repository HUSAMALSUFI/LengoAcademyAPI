using DareAcademy_BusinessLogic.SpecificReposoitory;
using DareAcademy_DataAccess.Domain;
using Microsoft.AspNetCore.Mvc;
using DareAcademy_API.Models;
using DareAcademy_DataAccess.Entity;
using DareAcademy_DataAccess.Context;
using System.Xml.Serialization;

namespace DareAcademy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly DareAcademyContext context;

        public CategoryController(ICategoryRepository _categoryRepository, DareAcademyContext _context)
        {
            categoryRepository = _categoryRepository;
            context = _context;
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> Insert(CategoryDTO categoryDTO)
        {
            try
            {
                int Id = await categoryRepository.Insert(categoryDTO);
                if (Id != 0)
                {
                    return Ok("Succsess");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = "Faild to add Category" });
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
                return StatusCode(StatusCodes.Status200OK, await categoryRepository.LoadAll());
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
                return StatusCode(StatusCodes.Status200OK, await categoryRepository.Load(Id));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }

        }
        [HttpGet]
        [Route("MainCategories")]
        public List<Category> MainCategories()
          {
            return categoryRepository.MainCategory();
        }
        [HttpGet]
        [Route("SubCategories")]
        public List<Category> SubCategories()
        {
            return categoryRepository.SubCategory();
        }
        [HttpGet]
        [Route("Count")]
        public List<Count_Courses> Count()
        {
            return categoryRepository.Count();
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(CategoryDTO categoryDTO)
        {
            try
            {
                await categoryRepository.Update(categoryDTO);
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
                await categoryRepository.Delete(Id);
                return Ok("Succsess");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
    }
}
