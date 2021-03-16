using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace BlogAppApi.Core.DTOs
{
    public class TokenDto
    {
        public int UserId { get; set; }
        public string UserRole { get; set; }
        public string AccessToken { get; set; }
        [Newtonsoft.Json.JsonIgnore]
        public DateTime AccessTokenExpiration { get; set; }
        public string RefreshToken { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public DateTime RefreshTokenExpiration { get; set; }      
    }
}
