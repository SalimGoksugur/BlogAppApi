
using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IRepositories;
using BlogAppApi.Core.IServices;
using BlogAppApi.Core.IUnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _userRefreshTokenService;

        public AuthenticationService(ITokenService tokenService, UserManager<AppUser> userManager,
            IUnitOfWork unitOfWork, IGenericRepository<UserRefreshToken> userRefreshTokenService)
        {

            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenService = userRefreshTokenService;
        }

        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) return Response<TokenDto>.Fail("Kullanıcı adı veya şifre hatalı", 400);
            if(user.EmailConfirmed!=true) return Response<TokenDto>.Fail("Email adresinizi doğrulamalısınız", 400);

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return Response<TokenDto>.Fail("Kullanıcı adı veya şifre hatalı", 400);
            }
            var token = _tokenService.CreateToken(user, await GetUserRole(user) );

            var userRefreshToken = await _userRefreshTokenService.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (userRefreshToken == null)
            {
                await _userRefreshTokenService.AddAsync(new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }

             _unitOfWork.Save();

            return Response<TokenDto>.Success(token, 200);
        }    

        public async Task<Response<TokenDto>> CreateTokenByRefreshToken(string refreshTokenCode)
        {
            var refreshToken = await _userRefreshTokenService.Where(x => x.Code == refreshTokenCode).SingleOrDefaultAsync();

            if (refreshToken == null)
            {
                return Response<TokenDto>.Fail("Refresh token not found", 404);
            }

            var user = await _userManager.FindByIdAsync(refreshToken.UserId.ToString());

            if (user == null)
            {
                return Response<TokenDto>.Fail("User Id not found", 404);
            }

            var tokenDto = _tokenService.CreateToken(user, await GetUserRole (user));

            refreshToken.Code = tokenDto.RefreshToken;
            refreshToken.Expiration = tokenDto.RefreshTokenExpiration;

             _unitOfWork.Save();

            return Response<TokenDto>.Success(tokenDto, 200);
        }

        public async Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenService.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null)
            {
                return Response<NoDataDto>.Fail("Refresh token not found", 404);
            }

            await _userRefreshTokenService.Remove(existRefreshToken);
             _unitOfWork.Save();
            return Response<NoDataDto>.Success(200);
        }

        public async Task<string> GetUserRole(AppUser user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);
            return userRoles.FirstOrDefault();
        }
    }
}
