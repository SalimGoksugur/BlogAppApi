using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary;
using SharedLibrary.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BlogAppApi.Service.Services
{
    public class TokenService :ITokenService
    {
        private readonly CustomTokenOption _tokenOption;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public TokenService(IOptions<CustomTokenOption> options, RoleManager<AppRole> roleManager,
            UserManager<AppUser>  userManager)
        {
            _tokenOption = options.Value;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];

            using var rnd = RandomNumberGenerator.Create();

            rnd.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }

        private IEnumerable<Claim> GetClaims(AppUser user, List<String> audiences, string userRole)
        {

            //Token Payload.Tokenda tutulacak veriler tanımlandı.
            var userList = new List<Claim> {
            new Claim( ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim (ClaimTypes.Role, userRole  ),
           // new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

            return userList;
        }



        public TokenDto CreateToken(AppUser user, string userRole)
        {
            var userID = user.Id;
            var accessTokenExpiration = DateTime.Now.AddMonths(_tokenOption.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMonths(_tokenOption.RefreshTokenExpiration);
            var securityKey = SignService.GetSymmetricSecurityKey(_tokenOption.SecurityKey);

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                expires: accessTokenExpiration,
                 notBefore: DateTime.Now,
                 claims: GetClaims(user, _tokenOption.Audience, userRole),
                 signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto
            {
                UserId = userID,
                UserRole = userRole,
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenExpiration
            };

            return tokenDto;
        }
      
    }
}
