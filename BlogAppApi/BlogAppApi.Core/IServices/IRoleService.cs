using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IServices
{
    public interface IRoleService
    {
        Task<Response<IEnumerable<RoleDto>>> GetAll();
        Task<Response<RoleDto>> GelRoleByName(string roleName);
        Task<Response<NoDataDto>> CreateRole(RoleCreateDto roleDto);
        Task<Response<NoDataDto>> DeleteRole(int id);
        Task<Response<NoDataDto>> AddUserToRole(AddUserToRoleDto dto);
        Task<Response<NoDataDto>> RemoveUserFromRole(AddUserToRoleDto dto);
        Task<Response<NoDataDto>> RemoveUserFromAllRoles(AppUser user);
        Task<Response<NoDataDto>> UpdateRole(RoleDto role);
    }
}
