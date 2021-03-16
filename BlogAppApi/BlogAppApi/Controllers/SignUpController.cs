using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : CustomBaseController
    {
        private readonly IUserService _userService;
        public SignUpController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto user)
        {
           return ActionResultInstance(await _userService.CreateUserAsync(user));
        }
    }
}
