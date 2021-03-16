using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppApi.Core.IServices
{
    public interface IMailService
    {
        Task SendMail(string toEmail, string subject, string content);
    }
}
