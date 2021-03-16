using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogAppApi.Core.Entities
{
    public class UserRefreshToken
    {        
        public int UserId { get; set; }
        public string Code { get; set; }
        public DateTime Expiration { get; set; } = DateTime.Now.AddMonths(60);
        public AppUser User { get; set; }
    }
}
