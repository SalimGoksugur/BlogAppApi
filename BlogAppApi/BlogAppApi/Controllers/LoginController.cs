using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : CustomBaseController
    {
        private readonly IUserService _userService;
        private readonly IAuthenticationService _authService;
        public LoginController(IUserService userService, IAuthenticationService authService)
        {
            _userService = userService;
            _authService = authService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto user)
        {
            return ActionResultInstance(await _authService.CreateTokenAsync(user));
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> SendCode(string email)
        {
            return ActionResultInstance(await _userService.SendSecurityCodeAsync(email));
        }
     
    }
}
