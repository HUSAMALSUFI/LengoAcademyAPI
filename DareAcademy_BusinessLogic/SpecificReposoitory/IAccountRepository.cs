using DareAcademy_DataAccess.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUser(SignUpDTO signUpModel);
        Task<IdentityResult> NewRole(RoleDTO roleModel);
        List<IdentityRole> GetRoles();
    }
}
