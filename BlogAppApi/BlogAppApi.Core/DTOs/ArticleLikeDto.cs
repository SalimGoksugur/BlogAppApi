using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class ArticleLikeDto:BaseDto
    {
        public int UserId { get; set; }
        public int ArticleId { get; set; }
    }
}
