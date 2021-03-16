using System;
using System.Collections.Generic;
using System.Text;

namespace BlogAppApi.Core.DTOs
{
    public class SavedArticleDto:BaseDto
    {
        public int ArticleId { get; set; }
        public int UserId { get; set; }
    }
}
