using BlogAppApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IServices
{
    public interface ISecurityService
    {
        //Geçerli kod varsa mevcut kodu yoksa; yeni kod oluşturup mail olarak gönderir ve ilgili kodu siler.
        public Task SendSecurityCodeAsync(AppUser user);
        public  Task<SecurityCode> FindCodeAsync(int userId);
        public bool HasValidCode(SecurityCode code);
        public void DeleteCode(SecurityCode code);
        public Task<bool> IsValidCode(int userId, string code );
        public string GenerateCode();
    }
}
