using BlogAppApi.Core.Entities;
using System;


namespace BlogAppApi.Core.Entities
{
   public class SecurityCode
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsValid { get; set; } = true;
        public AppUser User { get; set; }
    }
}
