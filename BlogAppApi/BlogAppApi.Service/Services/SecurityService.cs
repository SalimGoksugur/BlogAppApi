using BlogAppApi.Core.Entities;
using BlogAppApi.Core.IRepositories;
using BlogAppApi.Core.IServices;
using BlogAppApi.Core.IUnitOfWork;
using BlogAppApi.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Service.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISecurityCodeRepository _dbSet;
        private readonly IMailService _mailService;
        public SecurityService(IUnitOfWork unitOfWork, ISecurityCodeRepository dbSet, IMailService mailService)
        {
            _unitOfWork = unitOfWork;
            _dbSet = dbSet;
            _mailService = mailService;
        }
        public void DeleteCode(SecurityCode code)
        {
            _dbSet.Remove(code);
            _unitOfWork.Save();
           
        }

        public async Task SendSecurityCodeAsync(AppUser user)
        {
            string code;
            SecurityCode securityCode = await FindCodeAsync(user.Id);
            if (HasValidCode(securityCode))
            {
                 await _mailService.SendMail(user.Email, "Article App SecurityCode", securityCode.Code);
                return;
            }
            else
            {
                code = GenerateCode();
                SecurityCode sCode = new SecurityCode
                {
                    UserId = user.Id,
                    Code = code,
                    IsValid = true,
                };
                await _dbSet.AddAsync(sCode);
                 _unitOfWork.Save();
                await _mailService.SendMail(user.Email, "Article App SecurityCode", code);
            }           
        }
        public async Task<SecurityCode> FindCodeAsync(int userId)
        {
            SecurityCode code = await _dbSet.GetByIdAsync(userId);
            return code;
        }
        public bool HasValidCode(SecurityCode code)
        {
            if(code!= null)
            {
                return true;
            }
            return false;
        }

        public async Task <bool> IsValidCode(int userId, string code)
        {
           SecurityCode sCode=await FindCodeAsync(userId);
            if (HasValidCode(sCode))
            {
                if (sCode.Code == code)
                {
                    DeleteCode(sCode);
                    return true;
                }                    
            }
            return false;
        }
        public string GenerateCode()
        {
            var codeBuilder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i <= 5; i++)
            {
                int charType = random.Next(1, 4);
                if (charType == 1)
                {
                    codeBuilder.Append((char)random.Next(65, 91));
                }
                else if (charType == 2)
                {
                    codeBuilder.Append((char)random.Next(97, 123));
                }
                else
                {
                    codeBuilder.Append(random.Next(0, 10).ToString());
                }
            }
            return codeBuilder.ToString();
        }

    }
}
