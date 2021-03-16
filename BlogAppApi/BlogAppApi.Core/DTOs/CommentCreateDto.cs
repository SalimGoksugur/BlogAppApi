using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class CommentCreateDto
    {
        public int UserId { get; set; }
        public string Content { get; set; }
        public int ArticleId { get; set; }

    }
}
