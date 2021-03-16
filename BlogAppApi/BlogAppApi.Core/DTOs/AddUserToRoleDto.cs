using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class AddUserToRoleDto
    {
        public int UserId { get; set; }
        public string RoleName { get; set; }
    }
}
