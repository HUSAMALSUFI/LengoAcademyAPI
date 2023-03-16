using Azure;
using DareAcademy_BusinessLogic.SpecificReposoitory;
using DareAcademy_DataAccess.Application;
using DareAcademy_DataAccess.Domain;
using DareAcademy_API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DareAcademy_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        private readonly IConfiguration configuration;

        public AccountController(IAccountRepository _accountRepository, IConfiguration _configuration)
        {
            accountRepository = _accountRepository;
            configuration = _configuration;
        }

        [HttpPost]
        [Route("CreateAccount")]
        public async Task<IActionResult> CreateAccount(SignUpDTO signUp)
        {
            try
            {
                IdentityResult result = await accountRepository.CreateUser(signUp);
                if (result.Succeeded)
                {
                    return Ok("Succsess");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = "Faild to create user" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(RoleDTO roleModel)
        {
            try
            {
                var result = await accountRepository.NewRole(roleModel);
                if (result.Succeeded)
                {
                    return Ok("Succsess");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = "Faild to add Role" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Responses { Status = "Error", Message = ex.Message });
            }
        }
    
        [HttpGet]
        [Route("GetRoles")]
        public List<IdentityRole> GetRoles()
        {
            var liRole = accountRepository.GetRoles();
            return liRole;
        }
    }
}
