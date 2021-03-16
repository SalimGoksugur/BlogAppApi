using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : CustomBaseController
    {
        private readonly IRoleService _roleService;
        private readonly UserManager<AppUser> _userManager;
        public UserRolesController(IRoleService roleService, UserManager<AppUser> userManager)
        {
            _roleService = roleService;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> AddUserToRole(AddUserToRoleDto dto)
        {
           return ActionResultInstance(await _roleService.AddUserToRole(dto));
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> RemoveUserFromRole(int userId) 
        {
            return ActionResultInstance(await _roleService.RemoveUserFromAllRoles(await _userManager.FindByIdAsync(userId.ToString())));
        }


    }
}
