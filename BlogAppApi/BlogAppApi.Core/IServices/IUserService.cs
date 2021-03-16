using BlogAppApi.Core.DTOs;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IServices
{
    public interface IUserService
    {
        Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto);
        Task<Response<NoDataDto>> ConfirmEmailAsync(UserConfirmEmailDto userConfirmEmailDto);
        Task<Response<NoDataDto>> SendSecurityCodeAsync(string email);
        Task<Response<NoDataDto>> ChangePasswordAsync(ChangePasswordDto changePasswordDto);
        Task<Response<NoDataDto>> ChangePasswordByCodeAsync(ChangePasswordByCodeDto changePasswordByCodeDto);
    }
}
