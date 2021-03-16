using BlogAppApi.Core.DTOs;
using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.IServices
{
    public interface ITokenService
    {
        TokenDto CreateToken(AppUser user, string userRole);
    }
}
