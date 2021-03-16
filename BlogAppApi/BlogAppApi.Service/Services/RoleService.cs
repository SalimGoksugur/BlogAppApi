using AutoMapper;
using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IServices;
using BlogAppApi.SharedLibrary;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Service.Services
{
    public class RoleService : IRoleService
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleService(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public async Task<Response<NoDataDto>> CreateRole(RoleCreateDto role)
        {
           var result= _roleManager.CreateAsync(ObjectMapper.Mapper.Map<AppRole>(role)).Result;
            if (!result.Succeeded)
                return Response<NoDataDto>.Fail("Bir hata oldu, lütfen daha sonra tekrar deneyin", 400);
            return Response<NoDataDto>.Success(201);
        }
        public async Task<Response<NoDataDto>> DeleteRole(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return Response<NoDataDto>.Fail("Rol mevcut değil", 404);
            if (!_roleManager.DeleteAsync(role).Result.Succeeded)
                return Response<NoDataDto>.Fail("Bir hata oldu, lütfen daha sonra tekrar deneyin", 500);
            return Response<NoDataDto>.Success(204);
        }
        public async Task<Response<NoDataDto>> AddUserToRole(AddUserToRoleDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null)
                return Response<NoDataDto>.Fail("Kullanıcı bulunamadı", 400);
            var role =await _roleManager.FindByNameAsync(dto.RoleName);
            if (role == null)
                return Response<NoDataDto>.Fail("Rol bulunamadı", 400);
            await RemoveUserFromAllRoles(user);

           var result=  _userManager.AddToRoleAsync(user, dto.RoleName).Result;
            if (result.Succeeded)
                return Response<NoDataDto>.Success(201);            
            return Response<NoDataDto>.Fail("", 400);
        }

        public async Task<Response<NoDataDto>> RemoveUserFromRole(AddUserToRoleDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null)
                return Response<NoDataDto>.Fail("Kullanıcı bulunamadı", 400);
            var role =await _roleManager.FindByNameAsync(dto.RoleName);
            if (role == null)
                return Response<NoDataDto>.Fail("Rol bulunamadı", 400);
             return Response<NoDataDto>.Success(204);
        }
        public async Task<Response<NoDataDto>> RemoveUserFromAllRoles(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            foreach(var role in roles)
            {
               await _userManager.RemoveFromRoleAsync(user, role);
            }
            return Response<NoDataDto>.Success(204);
        }


        public async Task<Response<NoDataDto>> UpdateRole(RoleDto role)
        {
            var roleToUpdate =await _roleManager.FindByIdAsync(role.Id.ToString());
            if (roleToUpdate == null)
                return Response<NoDataDto>.Fail("Rol bulunamadı", 404);
            roleToUpdate.Name = role.Name;

            if (_roleManager.UpdateAsync(roleToUpdate).Result.Succeeded)
            {
              await  _roleManager.UpdateNormalizedRoleNameAsync(await _roleManager.FindByIdAsync(role.Id.ToString()));
                return Response<NoDataDto>.Success(204);

            }
            return Response<NoDataDto>.Fail("Bir hata oldu, sonra tekrar deneyin", 500);
        }

        public async Task<Response<IEnumerable<RoleDto>>> GetAll()
        {
            return Response<IEnumerable<RoleDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<RoleDto>>(_roleManager.Roles.ToList()), 200);
        }

        public async Task<Response<RoleDto>> GelRoleByName(string roleName)
        {
            return Response<RoleDto>.Success(ObjectMapper.Mapper.Map<RoleDto>( await _roleManager.FindByNameAsync(roleName)), 200);
        }
    }
}
