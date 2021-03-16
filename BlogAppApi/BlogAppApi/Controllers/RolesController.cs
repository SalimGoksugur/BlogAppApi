using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IServices;
using BlogAppApi.SharedLibrary;
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
    public class RolesController : CustomBaseController
    {
        private IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateDto role)
        {
            return ActionResultInstance(await _roleService.CreateRole(role));             
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            return ActionResultInstance(await _roleService.GetAll());
        }
        [HttpGet("{roleName}")] 
        public async Task<IActionResult> GetRoleByName(string roleName)
        {
            return ActionResultInstance(await _roleService.GelRoleByName(roleName));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRole(RoleDto roleDto)
        {
            return ActionResultInstance(await _roleService.UpdateRole(roleDto));
        }
        [HttpDelete("{roleId}")]
        public async Task<IActionResult> DeleteRole(int roleId)
        {
            return ActionResultInstance(await _roleService.DeleteRole(roleId));
        }

    }
}
