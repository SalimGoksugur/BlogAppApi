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
    public class ConfirmEmailController : CustomBaseController
    {
        private IUserService _userService;
        public ConfirmEmailController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmEmail(UserConfirmEmailDto dto)
        {
            return ActionResultInstance(await _userService.ConfirmEmailAsync(dto));
        }
    }
}
