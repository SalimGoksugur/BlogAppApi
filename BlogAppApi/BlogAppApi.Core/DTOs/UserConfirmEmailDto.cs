using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class UserConfirmEmailDto
    {
       public string Email { get; set; }
       public  string Code { get; set; }
    }
}
