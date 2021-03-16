using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IServices;
using BlogAppApi.Core.IUnitOfWork;
using BlogAppApi.SharedLibrary;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppApi.Service.Services
{
    public class UserService : IUserService
    {
        private readonly  UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ISecurityService _securityService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRoleService _roleService;
        
        public UserService(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,
            ISecurityService securityService, IUnitOfWork unitOfWork, IRoleService roleService)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _securityService = securityService;
            _signInManager = signInManager;
            _roleService = roleService;
        }
        public async Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new AppUser
            {
                UserName = createUserDto.UserName,
                Email = createUserDto.Email
            };
            var result =  _userManager.CreateAsync(user, createUserDto.Password).Result;
            if (result.Succeeded)
            {
                await _securityService.SendSecurityCodeAsync(user);
                return Response<UserDto>.Success(ObjectMapper.Mapper.Map<UserDto>(user), 201);
            }
            return Response<UserDto>.Fail("Bilgilerinizi kontrol edin.", 400);
        }
        public async Task<Response<NoDataDto>> ConfirmEmailAsync(UserConfirmEmailDto userConfirmEmailDto)
        {
            var user = await _userManager.FindByEmailAsync(userConfirmEmailDto.Email);
           
            if(await _securityService.IsValidCode(user.Id, userConfirmEmailDto.Code))
            {
                user.EmailConfirmed = true;
                var result=await _roleService.AddUserToRole(new AddUserToRoleDto {UserId=user.Id, RoleName="Üye" });
                if (result.StatusCode < 205)
                {
                    _unitOfWork.Save();
                    return Response<NoDataDto>.Success(200);
                }
                else
                    return Response<NoDataDto>.Fail("Lütfen daha sonra tekrar deneyiniz", 500);
            }          
            return Response<NoDataDto>.Fail("Geçersiz email veya kod girdiniz.", 404 );           
        }

        public async Task <Response<NoDataDto>> SendSecurityCodeAsync(string email)
        {
           var user=await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Response<NoDataDto>.Fail("Email ile kayıtlı kullanıcı bulunamadı", 404);
            }
            await _securityService.SendSecurityCodeAsync(user);
           
            return Response<NoDataDto>.Success(200 );
        }
        public async Task<Response<NoDataDto>> ChangePasswordAsync(ChangePasswordDto changePasswordDto)
        {
            AppUser user=await _userManager.FindByEmailAsync(changePasswordDto.Email);
            if (user == null)
            {
                return Response<NoDataDto>.Fail("Kullanıcı bulunamadı", 404);
            }
            if (!await _userManager.CheckPasswordAsync(user, changePasswordDto.OldPassword))
            {
                return Response<NoDataDto>.Fail("Şifreniz hatalı", 401 );
            }
            var result= await _userManager.ChangePasswordAsync(user, changePasswordDto.OldPassword, changePasswordDto.NewPassword);
            if (!result.Succeeded)
            {
                return Response<NoDataDto>.Fail("Bir hata oldu, daha sonra tekrar deneyiniz", 500);
                
            }
            await _signInManager.SignOutAsync();
            
            return Response<NoDataDto>.Success(200 );
        }
        public async Task<Response<NoDataDto>> ChangePasswordByCodeAsync(ChangePasswordByCodeDto changePasswordDto)
        {
            AppUser user = await _userManager.FindByEmailAsync(changePasswordDto.Email);

            if (user == null || changePasswordDto.Code==null || changePasswordDto.Email==null)
            {
                return Response<NoDataDto>.Fail("Bilgilerinizi kontrol edin", 400 );
            }
            if(!await _securityService.IsValidCode(user.Id, changePasswordDto.Code))
            {
                return Response<NoDataDto>.Fail("Bilgilerinizi kontrol edin", 400);
            }
            string passwordResetToken= await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, passwordResetToken, changePasswordDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();
                return Response<NoDataDto>.Fail("Bir hata oldu, daha sonra tekrar deneyin", 500);
            }
            await _signInManager.SignOutAsync();
            return Response<NoDataDto>.Success(202);
        }
       

    }
}
