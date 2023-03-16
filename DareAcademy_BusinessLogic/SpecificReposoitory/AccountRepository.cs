using Azure;
using DareAcademy_DataAccess.Application;
using DareAcademy_DataAccess.Domain;
using DareAcademy_DataAccess.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DareAcademy_BusinessLogic.SpecificReposoitory
{
    public class AccountRepository: IAccountRepository
    {
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;


        public AccountRepository(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }

        public async Task<IdentityResult> CreateUser(SignUpDTO signUp)
        {
            var newUser = new ApplicationUser()
            {
                FName = signUp.FName,
                LName=signUp.LName,
                Email = signUp.Email,
                PhoneNo = signUp.PhoneNo,
                Course_ID= signUp.Course_ID,
                Section_ID=signUp.Section_ID,
            };
            var result = await userManager.CreateAsync(newUser);
            var student = "0bc7e42e-fad3-47c1-969a-aefb260ec94d";
            if (result.Succeeded)
            {
                var role = await roleManager.FindByIdAsync(student);
                result = await userManager.AddToRoleAsync(newUser, role.Name);
            }
            return result;
        }

        public async Task<IdentityResult> NewRole(RoleDTO roleModel)
        {
            var newRole = new IdentityRole()
            {
                Name = roleModel.Name
            };

            var result = await roleManager.CreateAsync(newRole);
            return result;
        }
        public List<IdentityRole> GetRoles()
        {
            List<IdentityRole> liRole = roleManager.Roles.ToList();
            return liRole;
        }
       
    }
}
